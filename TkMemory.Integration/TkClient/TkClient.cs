// This file is part of TkMemory.

// TkMemory is free software. You can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License or (at your
// option) any later version.

// TkMemory is distributed in the hope that it will be useful but WITHOUT
// ANY WARRANTY, without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details.

// You should have received a copy of the GNU General Public License
// along with TkMemory. If not, please refer to:
// https://www.gnu.org/licenses/gpl-3.0.en.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoHotkey.Interop;
using AutoHotkey.Interop.ClassMemory;
using Serilog;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties;
using TkMemory.Integration.TkClient.Properties.Activity;
using TkMemory.Integration.TkClient.Properties.Commands;
using TkMemory.Integration.TkClient.Properties.Environment;
using TkMemory.Integration.TkClient.Properties.Group;
using TkMemory.Integration.TkClient.Properties.Npcs;
using TkMemory.Integration.TkClient.Properties.Self;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client by reading the memory of the application.
    /// </summary>
    public abstract class TkClient
    {
        #region Fields

        internal int TauntTargetIndex;

        private const int MaxEntitiesToScan = 100;
        private const int MaxNpcsToTrack = 100;
        private const int NpcScanCooldownInSeconds = 10;
        private const int TargetingDelayInMilliseconds = 20;

        private readonly AutoHotkeyEngine _ahk = AutoHotkeyEngine.Instance;
        private readonly DateTime _botStartTime;
        /// <summary>Matches all capital letters not enclosed between braces.</summary>
        private readonly Regex _controlSendRegex = new Regex(@"[A-Z](?![^{}]*})");
        private readonly string _npcTargetingKey;
        private readonly int _processId;
        private readonly uint _startingExp;

        private int _manaRestorationItemUsageCount;
        private int _previousGroupSize;
        private uint _previousLastGroupMemberUid;
        private DateTime _timeOfPreviousNpcScan;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a player.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        protected TkClient(ClassMemory classMemory)
        {
            Activity = new TkActivity(classMemory);
            Chat = new TkChat(classMemory);
            Environment = new TkEnvironment(classMemory);
            Group = new TkGroup(classMemory);
            Inventory = new TkInventory(classMemory);
            Npcs = new List<Npc>();
            Self = new TkSelf(classMemory);
            Targeting = new TkTargeting(classMemory);

            _npcTargetingKey = IsTabVSwapOff()
                ? Keys.Tab
                : Keys.V;

            _processId = Convert.ToInt32(classMemory.ToString().Replace("_classMemory", string.Empty));
            _botStartTime = DateTime.Now;
            _startingExp = Self.Exp;
            _timeOfPreviousNpcScan = DateTime.Now.AddSeconds(-NpcScanCooldownInSeconds);
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// The base path that a player has chosen excluding subpath and mark rank.
        /// </summary>
        public enum BasePath { Warrior, Rogue, Mage, Poet, Peasant }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Gets information activity that is affecting the player.
        /// </summary>
        public TkActivity Activity { get; }

        /// <summary>
        /// Gets information about recent activity in the chat window.
        /// </summary>
        public TkChat Chat { get; }

        /// <summary>
        /// Gets information about the current environment.
        /// </summary>
        public TkEnvironment Environment { get; }

        /// <summary>
        /// Gets information about the player's group and its members.
        /// </summary>
        public TkGroup Group { get; }

        /// <summary>
        /// Gets information about the items currently possessed by the player.
        /// </summary>
        public TkInventory Inventory { get; }

        /// <summary>
        /// Gets a list of NPCs currently on-screen.
        /// </summary>
        public List<Npc> Npcs { get; }

        /// <summary>
        /// Gets properties specific to the player currently logged into the client.
        /// </summary>
        public TkSelf Self { get; }

        /// <summary>
        /// Gets information about whom the player is currently targeting for spells.
        /// </summary>
        public TkTargeting Targeting { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Generates a simple report of the experience earned and the rate of earning from the time
        /// the bot was started until the current time. This resets each time the bot is started, and
        /// it will not be accurate if experience was sold or earned beyond the maximum. It uses a simple
        /// difference between what you have when the bot stops and what you had when the bot started.
        /// </summary>
        /// <returns>The total and rate of experience earned since the bot started.</returns>
        public string GetExpReport()
        {
            var minutesSinceStart = (DateTime.Now - _botStartTime).TotalMinutes;
            var expSinceStart = Self.Exp - _startingExp;
            var expRate = expSinceStart / minutesSinceStart;

            return $"{Self.Name} earned {expSinceStart:N0} experience at a rate of {expRate:N0} exp/minute.";
        }

        /// <summary>
        /// Generates a simple report of the number of mana restoration items that had to be used to cast
        /// spells from the time the bot was started until the current time. This resets each time the bot
        /// is restarted, and it will not necessarily be 100% accurate in cases where the server does not
        /// pick up an item usage command or when usages attempted exceeds the quantity available, but
        /// approximation is good enough. This is just for fun/informational purposes and for getting a very
        /// general idea of how many mana restoration items need to be kept on hand.
        /// </summary>
        /// /// <returns>The total and rate of mana restoration items used since the bot started.</returns>
        public string GetManaRestorationItemUsageReport()
        {
            var minutesSinceStart = (DateTime.Now - _botStartTime).TotalMinutes;
            var expRate = _manaRestorationItemUsageCount / minutesSinceStart;

            return $"{Self.Name} had to use a mana restoration item {_manaRestorationItemUsageCount:N0} times at a rate of {expRate:N0} uses/minute.";
        }

        /// <summary>
        /// Determines whether or not a spell target is currently off-screen. This is used to
        /// determine whether or not a spell can be cast on the target if attempted. Please
        /// note that this is unreliable when the caster is off-center in the map due to being
        /// near one or more of its edges. In that case, it is quite possible for a target to
        /// be on-screen but still be out of range for spells. There is some risk of the bot
        /// getting stuck repeatedly attempting to cast a spell on a multibox group member
        /// target that it thinks is within range. There is also risk of the bot thinking it
        /// successfully cast a spell on an external group member or NPC target when it did
        /// not. It is best practice to keep the caster centered within the screen as often as
        /// possible.
        /// </summary>
        /// <param name="targetUid">The UID of the target.</param>
        /// <param name="targetableSpell">Any targetable spell.</param>
        /// <returns>True if the target is off-screen; false otherwise.</returns>
        public async Task<bool> IsTargetOffScreen(uint targetUid, Spell targetableSpell)
        {
            if (targetableSpell == null)
            {
                throw new ArgumentNullException(nameof(targetableSpell), "Cannot determine whether or not a target is off-screen without a targetable spell.");
            }

            Targeting.Spell = targetUid;

            if (targetUid == Self.Uid)
            {
                return false;
            }

            var keys = $"{Keys.Esc}Z{targetableSpell.Letter}{Keys.Esc}";
            Send(keys);

            await Task.Delay(20);

            return Targeting.Spell == Self.Uid;
        }

        /// <summary>
        /// Sends keystrokes to the target process. Capital letters can be used normally to have the
        /// Shift modifier correctly applied automatically (e.g. "Zb" will automatically be sent as
        /// "{Shift down}z{Shift up}b"). Shift modifiers on non-alpha characters and all other modifiers
        /// on any character must be input manually. You should never use the shorthand for modifier
        /// keys (e.g. "^" for Ctrl), and you should always use the full down/up toggles (e.g.
        /// "{Ctrl down}" and "{Ctrl up}" for Ctrl).
        /// </summary>
        /// <param name="keys">The keystrokes to send to the client.</param>
        public void Send(string keys)
        {
            keys = _controlSendRegex.Replace(keys, upperCaseLetter => $"{Keys.ShiftDown}{upperCaseLetter.ToString().ToLower()}{Keys.ShiftUp}");
            var command = $"ControlSend, , % \"{Keys.ReleaseModifiers}{keys}{Keys.ReleaseModifiers}\", \"ahk_pid {_processId}\"";
            Log.Verbose(command);
            _ahk.ExecRaw(command);
        }

        /// <summary>
        /// Updates the lists of multibox and external members in a player's group. Updates are only
        /// performed if a change is detected.
        /// </summary>
        /// <param name="activeClients">All clients currently being operated on the same PC as the bot.</param>
        public void UpdateGroup(ActiveClients activeClients)
        {
            var currentGroupSize = Group.Size;
            var lastGroupMemberPosition = currentGroupSize - 1;
            var lastGroupMemberUid = Group.GetUid(lastGroupMemberPosition);

            if (currentGroupSize == _previousGroupSize &&
                lastGroupMemberUid == _previousLastGroupMemberUid)
            {
                return;
            }

            _previousGroupSize = currentGroupSize;
            _previousLastGroupMemberUid = lastGroupMemberUid;

            Group.MultiboxMembers = new List<TkClient>();
            var newExternalMembers = new List<GroupMember>();
            var clients = activeClients.Clients.ToArray();

            for (var i = 0; i < currentGroupSize; i++)
            {
                var uid = Group.GetUid(i);

                if (uid == Self.Uid)
                {
                    continue;
                }

                var matchingClient = clients.FirstOrDefault(client => client.Self.Uid == uid);

                if (matchingClient == null)
                {
                    newExternalMembers.Add(new GroupMember(i, Group.GetName(i), uid));
                    continue;
                }

                Group.MultiboxMembers.Add(matchingClient);
            }

            // The following may seem overcomplicated, but the simpler approach of just completely replacing the existing list of external group members
            // with the new list causes all status effect timers of existing group members to be lost. This approach protects that data.

            // Remove existing external group members that are not still in the group (i.e. not in the new list)
            for (var i = Group.ExternalMembers.Count - 1; i >= 0; i--)
            {
                if (newExternalMembers.All(x => x.Uid != Group.ExternalMembers[i].Uid)) // If existing external group member is not in the new list
                {
                    Group.ExternalMembers.RemoveAt(i);
                }
            }

            // Add external group members from the new list who are not already in the existing list
            Group.ExternalMembers.AddRange(newExternalMembers.Where(x => Group.ExternalMembers.All(y => y.Uid != x.Uid)));

            if (Group.Size == 0)
            {
                Log.Warning($"{Self.Name} is not part of a group.");
                return;
            }

            Log.Information($"{Self.Name}'s group membership was updated.");
        }

        /// <summary>
        /// Scans the current screen for NPCs and adds any that are not already in the bot's NPC
        /// list to that list. By default, this happens no more often than once every 10 seconds,
        /// but it can also be done on command by setting the overriding that cooldown feature.
        /// </summary>
        /// <param name="targetableSpell">Any targetable spell.</param>
        /// <param name="overrideCooldown">Set to true for an on-demand scan regardless of current
        /// cooldown.</param>
        /// <returns>True if a scan is performed; false if the cooldown prevented a scan.</returns>
        public virtual async Task<bool> UpdateNpcs(Spell targetableSpell, bool overrideCooldown = false)
        {
            if (targetableSpell == null)
            {
                throw new ArgumentNullException(nameof(targetableSpell), "NPC list update failed because a non-null targetable spell was not provided.");
            }

            if (!overrideCooldown && (DateTime.Now - _timeOfPreviousNpcScan).TotalSeconds < NpcScanCooldownInSeconds)
            {
                return false;
            }

            _timeOfPreviousNpcScan = DateTime.Now;
            await Activity.WaitForCommandCooldown();
            Send(Keys.Esc + _npcTargetingKey);
            await Task.Delay(TargetingDelayInMilliseconds);
            var firstUid = Targeting.Npc;

            if (firstUid == Self.Uid)
            {
                Send(Keys.Esc);
                return false;
            }

            AddNpc(firstUid);

            for (var i = 0; i < MaxEntitiesToScan - 1; i++)
            {
                Send(_npcTargetingKey);
                await Task.Delay(TargetingDelayInMilliseconds);
                var uid = Targeting.Npc;

                if (uid == firstUid)
                {
                    break;
                }

                AddNpc(uid);

                if (Npcs.Count >= MaxNpcsToTrack)
                {
                    break;
                }
            }

            TauntTargetIndex = Npcs.Count - 1;
            Send(Keys.Esc);
            return true;
        }

        #endregion

        #region Internal Methods

        internal void IncrementManaRestorationItemUsageCount(int usages)
        {
            _manaRestorationItemUsageCount += usages;
        }

        #endregion Internal Methods

        #region Private Methods

        private void AddNpc(uint uid)
        {
            var isAlreadyInNpcList = Npcs.Any(npc => uid == npc.Uid);

            if (!isAlreadyInNpcList)
            {
                Npcs.Insert(0, new Npc(uid));
            }
        }

        private bool IsTabVSwapOff()
        {
            Send($"{Keys.Esc}v{Keys.Home}{Keys.Esc}");
            Thread.Sleep(TargetingDelayInMilliseconds);
            var playerTargetUid = Targeting.Player;
            return playerTargetUid == Self.Uid;
        }

        #endregion Private Methods
    }
}
