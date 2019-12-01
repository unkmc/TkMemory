# TkMemory
TkMemory is a library that provides a framework for building game trainers or "bots" for ClassicTK (CTK), a now defunct private server of NexusTK (NTK).

# Features
TkMemory offers many features not available in any freely-distributed trainer to date:

- No configuration required
  - Spells and items are automatically detected and used regardless of in-game setup
  - Trainers automatically support group members and detect group membership changes
- Efficient usage of consumable items
  - Consumables are automatically replaced with the next available alternative after consumption
  - Partially-used consumables are automatically used before any untouched consumables
  - Mana restoration items will automatically be used when trying to cast a spell with insufficient mana
- Robust spell-casting eligibility logic
  - Cast spells on demand, by vita/mana percent, or as soon as they would be 100% effective
    - e.g. **Heal** whenever a target's **Current Vita <= 80%**
    - e.g. **Heal** whenever a target's **Max Vita - Current Vita >= Heal amount**
  - Cast or do not cast certain spells based on target's path
    - e.g. Do not cast **Valor** on known Mages or Poets, only Rogues and Warriors
- Memory reads instead of timers whenever possible
  - Reads own client for active buffs, debuffs, aethers, etc. and responds to changes immediately and automatically
  - Reads all active clients when multiboxing to enable equally sophisticated support for group members
- Automatic detection and handling of off-screen targets
  - Prevents attempts to cast spells on targets that leave the screen
  - Resumes casting spells on targets that return to the screen
- Includes framework for logging of key events and metrics
  - Actions taken and the targets of targetable actions
  - Experience gained and the rate of gain
  - Number of mana restoration items and the rate of usage
  - Hotkey activity of the user
- Most actions can be performed with a single line of code
  - Simple parameters can be used to fine-tune actions and criteria for taking action
  - Trainer behavior can be customized simply by adding/removing/reordering single lines of code
- Easy access to all known memory reads for the CTK client without having to manage memory addresses
- [AutoHotkey.Interop.ClassMemory](https://github.com/elodon/AutoHotkey.Interop.ClassMemory/) sends keystrokes without requiring installation or knowledge of AutoHotkey
- .NET development offers a better IDE, compiler, and debugger compared to AutoHotkey
- Code is open source, documented, and adheres to best practices
- Many additional features are already stubbed out for future implementation

> The real advantage of TkMemory is that it is not a trainer. It is a framework that abstracts away the complex technical details of implementing a generic CTK trainer so that you can focus on the behavioral logic of your own custom trainer.

# Usage
The TkMemory solution contains a demo project that shows how to apply this library to build a trainer. That demo provides the most comprehensive example of how to implement TkMemory, but I will cover a few basics and some of the less obvious and intuitive features.

Start by finding all active clients on your PC using the name of the game's executable, and from that list of clients, you can get the one you want to automate:

```csharp
clients = new ActiveClients("ClassicTK");
poet = clients.GetPoet(); 
```

If you had multiple Poet clients running, you could differentiate between them using optional parameters:

```csharp
poet2 = clients.GetPoet(1); // Gets the second Poet client it finds
myPoet = clients.GetPoet("Orb"); // Gets the client that is logged in as a Poet named Orb
```

Next, you need to tell the trainer how often to execute commands. This can be anything from 333 to 1,000 milliseconds.

```csharp
poet.Activity.DefaultCommandCooldown = 333;
```

You want this to be a high enough number that the server can keep up without missing commands, but the smaller you can get it, the more efficient and effective the trainer will be. CTK can handle 333, but lag or a less responsive server could force you to increase the cooldown.

> Logging is very helpful in determining an appropriate cooldown. A discrepancy between logged activity and actual in-game activity indicates a missed command. Occasional missed commands are inevitable, but you should adjust the cooldown such that they are uncommon.

You can set your trainer up to run completely autonomously, or you can add hotkeys to toggle certain functionality on demand. The following example demonstrates how to set up a toggle for pausing the trainer and assigning it to the F1 key.

```csharp
var isBotPaused = new AutoHotkeyToggle("F1", "isBotPaused", false);
var myToggles = new[] { isBotPaused };
AutoHotkeyEngine.Instance.LoadToggles(myToggles);
```

That concludes the setup. After that, you just need to create a loop for your own trainer command logic.

```csharp
while (true)
{
  if (isBotPaused.Value) continue;
  if (await poet.Commands.Heal.HealGroupIfEligible()) continue;
  if (await poet.Commands.Attacks.ZapNpcs()) continue;
}
```

Every command returns true if it results in an action being taken and false otherwise. I highly recommend using this to exit each loop iteration as soon as an action is taken (as demonstrated above). That ensures that the trainer will always perform the highest-priority command.

> The recommended way to make your own trainers is to fork my [TkMemory.Application](https://github.com/elodon/TkMemory.Application) repository that has a prototype trainer for each path, and use each as a template. Simply modify the hotkey mappings and add/remove/rearrange commands in the `while` loop to customize the behavior of the trainer.

# Warnings
TkMemory can be used to build sophisticated and very effective trainers, but no trainer is perfect. Here are some risks to be aware of:

- Trainer will fail if your character is missing a quintessential skill
  - e.g. Poet trainer without a targetable heal spell will fail
  - e.g. _Any_ trainer without a targetable zap spell (e.g. **Taunt**, **Ignite**) will fail
    - Targetable zaps are used for tracking and targeting on-screen entities
- On/off-screen targeting logic is unreliable when the character is not centered on the screen
  - Being off-center allows targets to be on-screen but still out of range for spells which can lead to missed commands or even an infinite loop of repeatedly trying to cast a spell on an out-of-range target
- Extremely short duration debuffs (e.g. **Static**, **Pestilence**) can cause severe inefficiencies
  - e.g. Assuming one commands per second and 15 targets on-screen, a debuff with a 10 second duration cannot be cast on all targets before it expires on the first targets
    - Effectively creates an infinite loop of that debuff that prevents lower priority commands from ever being called
- Variable duration debuffs (e.g. **Venom**) will not have perfect timing
  - Debuffs on NPCs are necessarily timer-based and require estimation in the absence of a consistent duration
- Missed commands for timer-based logic can have long-lasting effects
  - e.g. If a **Scourge** command is missed by the server, the trainer will not know to try again until the full would-be duration of the spell has elapsed
  - Spells with failure rates (e.g. **Paralyze**) effectively create the same issue whenever the spell fails
  - NPCs curing themselves of debuffs cannot be detected and effectively create the same issue
- Far more data is available for multibox group members than for external group members
  - Buffs/debuffs can be read directly and supported automatically for multibox group members
  - Buffs/debuffs cannot be read directly for external group members and must rely on timer-based logic
  - Vita/mana can be read directly and supported automatically regardless of the type of group member
  - All other things being equal, support priority is oneself, then multibox group members, then 
external group members
- Spell commands rely on the accuracy of names, effects, costs, durations, and aethers on Nexus Atlas to function correctly
  - Though several known inaccuracies have already been corrected
- Item commands rely on the accuracy of names, effects, and stack sizes on Nexus Atlas to function correctly

The worst vulnerability--as with any application--is an unexpected fatal error. My [TkMemory.Application](https://github.com/elodon/TkMemory.Application) repository includes a demo launcher that monitors trainers and automatically restarts any that stop. Use it or something similar to mitigate this risk.

Fatal errors within AutoHotkey, not the trainer, are more problematic. AutoHotkey creates an error prompt that essentially pauses the trainer until you close it. That prevents the trainer from stopping which prevents the launcher from restarting it.

Neither scenario is common, and as long as you are not using the trainer unattended (which you should not be), you can fix even the worst of errors with a few clicks.

# Known Bugs
- TkMemory relies on the tab targeting feature of CTK for tracking NPCs. Sometimes when a trainer is first started, something goes wrong with tab targeting and the trainer does not detect any NPCs. This only happens the first time a trainer is started, so the current workaround is simply to restart the trainer.

# Untested Features
Unfortunately, CTK was shut down before I was able to finish testing TkMemory. The following is a list of implemented features that have not been fully tested. Some (e.g. **Whirlwind**) are _extremely_ similar to other vetted features and are considered very low-risk, but others (e.g. **Restore**, **Rage**/**Cunning**) implement unique logic with a relatively higher risk of defects.

- Whirlwind
- Lethal Strike
- Hellfire
- Inferno
- Doze
- Sleep
- Rage/Cunning
- Restore
- Harden Body

I should also note that while I am reasonably certain that spells are correctly detected and used regardless of alignment, it was prohibitively impractical to test every spell of every alignment. The same is true of items.

# Terms of Use
This trainer framework is built very specifically for the mechanics of CTK, and it is unlikely to be of much use on any other private server without source code changes. Furthermore, not all private servers allow trainers like CTK did. Use of this library on any server in any manner that is prohibited by that server is a violation of the terms of use.

NTK does not allow trainers, and use of this library in NTK is a violation of the terms of use. Even if NTK's trainer policies changed, you would find NTK to be so much less responsive than CTK that you would have to slow the trainer down to its slowest possible cooldown of one command per second just so that NTK could keep up. It would still work, but it would be far less efficient and impressive than what it would be with CTK's capacity for three commands per second.

There are no private servers that allow unattended or "AFK" use of trainers, and use of this library for an unattended trainer is a violation of the terms of use.
