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
using System.Diagnostics;
using System.Linq;
using System.Text;
using Serilog;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient {
    /// <summary>
    /// Provides information about all clients currently running on the same PC as the bot
    /// and to which base path the player from each client belongs.
    /// </summary>
    public class ActiveClients {
        #region Fields

        private readonly string _processName;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Examines every active client and sorts each by the base path of the its player.
        /// </summary>
        /// <param name="processName">The name of the executable of the client (excluding the
        /// ".exe" extension).</param>
        public ActiveClients(string processName) {
            _processName = processName;

            Mages = new List<MageClient>();
            Poets = new List<PoetClient>();
            Rogues = new List<RogueClient>();
            Warriors = new List<WarriorClient>();
            Peasants = new List<PeasantClient>();

            var processes = Process.GetProcesses();
            Log.Information("All processes ({Length})", processes.Length);
            foreach (var process in processes) {
                Log.Information("Name: ({Length})", process.ProcessName);
            }

            Log.Information("Retrieving process list by name, \"{processName}\"...", processName);
            var clients = Process.GetProcessesByName(processName);
            Log.Information("Got {Length} clients", clients.Length);

            foreach (var client in clients) {
                var tkClientFactory = new TkClientFactory(client.Id);
                var path = tkClientFactory.GetBasePath();
                Log.Information("Found client path, \"{path}\"", path);
                switch (path) {
                    case TkClient.BasePath.Mage:
                        Mages.Add(tkClientFactory.BuildMage());
                        break;
                    case TkClient.BasePath.Poet:
                        Poets.Add(tkClientFactory.BuildPoet());
                        break;
                    case TkClient.BasePath.Rogue:
                        Rogues.Add(tkClientFactory.BuildRogue());
                        break;
                    case TkClient.BasePath.Warrior:
                        Warriors.Add(tkClientFactory.BuildWarrior());
                        break;
                    case TkClient.BasePath.Peasant:
                        Peasants.Add(tkClientFactory.BuildPeasant());
                        break;
                    default:
                        throw new Exception($"Invalid path '{tkClientFactory.TkSelf.Path}' could not be classified into a base path.");
                }
            }

            Clients = GetClients();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// A list of all clients that are active on the same PC as the bot.
        /// </summary>
        public IEnumerable<TkClient> Clients { get; }

        /// <summary>
        /// A list of all clients in which the logged-in player has a base path of Mage.
        /// </summary>
        public List<MageClient> Mages { get; }

        /// <summary>
        /// A list of all clients in which the logged-in player has a base path of Poet.
        /// </summary>
        public List<PoetClient> Poets { get; }

        /// <summary>
        /// A list of all clients in which the logged-in player has a base path of Rogue.
        /// </summary>
        public List<RogueClient> Rogues { get; }

        /// <summary>
        /// A list of all clients in which the logged-in player has a base path of Warrior.
        /// </summary>
        public List<WarriorClient> Warriors { get; }

        /// <summary>
        /// A list of all clients in which the logged-in player has a base path of Peasant.
        /// </summary>
        public List<PeasantClient> Peasants { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Gets a Mage client from the list of active Mage clients. The first client in the
        /// list will be selected unless a specific position within the list is specified.
        /// </summary>
        /// <param name="index">The zero-indexed position within the list to select from.</param>
        /// <returns>The Mage client from the specified position.</returns>
        public MageClient GetMage(int index = 0) {
            if (Mages.Count < index + 1) {
                ThrowIndexOutOfRangeException("Mage", index, Mages.Count);
            }

            return Mages[index];
        }

        /// <summary>
        /// Gets a Poet client from the list of active Poet clients. The first client in the
        /// list will be selected unless a specific position within the list is specified.
        /// </summary>
        /// <param name="index">The zero-indexed position within the list to select from.</param>
        /// <returns>The Poet client from the specified position.</returns>

        public PoetClient GetPoet(int index = 0) {
            if (Poets.Count < index + 1) {
                ThrowIndexOutOfRangeException("Poet", index, Poets.Count);
            }

            return Poets[index];
        }

        /// <summary>
        /// Gets a Rogue client from the list of active Rogue clients. The first client in the
        /// list will be selected unless a specific position within the list is specified.
        /// </summary>
        /// <param name="index">The zero-indexed position within the list to select from.</param>
        /// <returns>The Rogue client from the specified position.</returns>

        public RogueClient GetRogue(int index = 0) {
            if (Rogues.Count < index + 1) {
                ThrowIndexOutOfRangeException("Rogue", index, Rogues.Count);
            }

            return Rogues[index];
        }

        /// <summary>
        /// Gets a Warrior client from the list of active Warrior clients. The first client in the
        /// list will be selected unless a specific position within the list is specified.
        /// </summary>
        /// <param name="index">The zero-indexed position within the list to select from.</param>
        /// <returns>The Warrior client from the specified position.</returns>

        public WarriorClient GetWarrior(int index = 0) {
            if (Warriors.Count < index + 1) {
                ThrowIndexOutOfRangeException("Warrior", index, Warriors.Count);
            }

            return Warriors[index];
        }

        /// <summary>
        /// Gets a Peasant client from the list of active Peasant clients. The first client in the
        /// list will be selected unless a specific position within the list is specified.
        /// </summary>
        /// <param name="index">The zero-indexed position within the list to select from.</param>
        /// <returns>The Peasant client from the specified position.</returns>

        public PeasantClient GetPeasant(int index = 0) {
            if (Peasants.Count < index + 1) {
                ThrowIndexOutOfRangeException("Peasant", index, Peasants.Count);
            }

            return Peasants[index];
        }

        /// <summary>
        /// Gets a Mage client from the list of active Mage clients. The client selected is the
        /// one in which the currently logged-in player matches the specified name.
        /// </summary>
        /// <param name="name">The name of the player logged into the client.</param>
        /// <returns>The Mage client that is logged in as the specified player.</returns>

        public MageClient GetMage(string name) {
            var client = Mages.FirstOrDefault(x => string.Equals(name, x.Self.Name, StringComparison.OrdinalIgnoreCase));

            if (client == null) {
                ThrowNullReferenceException("Mage", name);
            }

            return client;
        }

        /// <summary>
        /// Gets a Poet client from the list of active Poet clients. The client selected is the
        /// one in which the currently logged-in player matches the specified name.
        /// </summary>
        /// <param name="name">The name of the player logged into the client.</param>
        /// <returns>The Poet client that is logged in as the specified player.</returns>

        public PoetClient GetPoet(string name) {
            var client = Poets.FirstOrDefault(x => string.Equals(name, x.Self.Name, StringComparison.OrdinalIgnoreCase));

            if (client == null) {
                ThrowNullReferenceException("Poet", name);
            }

            return client;
        }

        /// <summary>
        /// Gets a Rogue client from the list of active Rogue clients. The client selected is the
        /// one in which the currently logged-in player matches the specified name.
        /// </summary>
        /// <param name="name">The name of the player logged into the client.</param>
        /// <returns>The Rogue client that is logged in as the specified player.</returns>

        public RogueClient GetRogue(string name) {
            var client = Rogues.FirstOrDefault(x => string.Equals(name, x.Self.Name, StringComparison.OrdinalIgnoreCase));

            if (client == null) {
                ThrowNullReferenceException("Rogue", name);
            }

            return client;
        }

        /// <summary>
        /// Gets a Warrior client from the list of active Warrior clients. The client selected is the
        /// one in which the currently logged-in player matches the specified name.
        /// </summary>
        /// <param name="name">The name of the player logged into the client.</param>
        /// <returns>The Warrior client that is logged in as the specified player.</returns>

        public WarriorClient GetWarrior(string name) {
            var client = Warriors.FirstOrDefault(x => string.Equals(name, x.Self.Name, StringComparison.OrdinalIgnoreCase));

            if (client == null) {
                ThrowNullReferenceException("Warrior", name);
            }

            return client;
        }

        /// <summary>
        /// Gets a Peasant client from the list of active Peasant clients. The client selected is the
        /// one in which the currently logged-in player matches the specified name.
        /// </summary>
        /// <param name="name">The name of the player logged into the client.</param>
        /// <returns>The Peasant client that is logged in as the specified player.</returns>

        public PeasantClient GetPeasant(string name) {
            var client = Peasants.FirstOrDefault(x => string.Equals(name, x.Self.Name, StringComparison.OrdinalIgnoreCase));

            if (client == null) {
                ThrowNullReferenceException("Peasant", name);
            }

            return client;
        }

        /// <summary>
        /// Gets a client from the list of active clients regardless of path.
        /// The client selected is the one in which the currently logged-in player
        /// matches the specified name.
        /// </summary>
        /// <param name="name">The name of the player logged into the client.</param>
        /// <returns>The client that is logged in as the specified player.</returns>

        public TkClient GetClient(string name) {
            var clients = new List<TkClient>();

            clients.AddRange(Mages);
            clients.AddRange(Poets);
            clients.AddRange(Rogues);
            clients.AddRange(Warriors);

            var client = clients.FirstOrDefault(x => string.Equals(name, x.Self.Name, StringComparison.OrdinalIgnoreCase));

            if (client == null) {
                ThrowNullReferenceException(name);
            }

            return client;
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<TkClient> GetClients() {
            var clients = new List<TkClient>();

            clients.AddRange(Mages);
            clients.AddRange(Poets);
            clients.AddRange(Rogues);
            clients.AddRange(Warriors);

            return clients;
        }

        private void ThrowIndexOutOfRangeException(string type, int index, int count) {
            var sb = new StringBuilder();

            sb.Append($"Could not get a {_processName} {type} client at index {index}. ");

            switch (count) {
                case 0:
                    sb.Append($"No active {_processName} {type} clients were found.");
                    break;
                case 1:
                    sb.Append($"Only one active {_processName} {type} client was found.");
                    break;
                default:
                    sb.Append($"Only {count} active {_processName} {type} clients were found.");
                    break;
            }

            throw new IndexOutOfRangeException(sb.ToString());
        }

        private void ThrowNullReferenceException(string name) {
            throw new NullReferenceException($"Could not find an active TK client for named '{name}'.");
        }

        private void ThrowNullReferenceException(string type, string name) {
            throw new NullReferenceException($"Could not find an active {_processName} client for a {type} named '{name}'.");
        }

        #endregion Private Methods
    }
}
