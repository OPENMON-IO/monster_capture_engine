// =============================================================================
// OpenMon MCE — Quick Start: Wild Battle Setup
// =============================================================================
//
// This sample shows the basic MCE battle API: inject services via Zenject,
// configure a wild encounter, start it, and react to the result.
//
// For the full engine, visit https://www.openmon.io
// Copyright (c) 2024-2026 OpenMon.IO. All rights reserved.
// =============================================================================

using System.Threading.Tasks;
using OpenMon.MCE;
using OpenMon.MCE.Data;
using UnityEngine;
using Zenject;

namespace OpenMon.MCE.Samples
{
    /// <summary>
    /// Minimal example: trigger a wild encounter from a grass tile.
    /// In production MCE, encounters are triggered automatically by the
    /// EncounterTile system. This shows the underlying API.
    /// </summary>
    public class QuickStartBattle : MonoBehaviour
    {
        // MCE uses Zenject for DI. All managers are .AsSingle().Lazy().
        [Inject] private IBattleManager battleManager;
        [Inject] private IWorldManager worldManager;
        [Inject] private IRoster playerRoster;
        [Inject] private IDialogManager dialogManager;

        public async Task TriggerWildEncounter()
        {
            // 1. Check for encounters at the player's tile.
            var encounters = worldManager.GetEncounterData(worldManager.PlayerPosition);
            if (encounters == null) return;

            // 2. Roll a random monster from the encounter table.
            var slot = encounters.Slots[Random.Range(0, encounters.Slots.Count)];
            int level = Random.Range(slot.MinLevel, slot.MaxLevel + 1);

            // 3. Configure the battle.
            var config = new BattleConfig
            {
                Type         = BattleType.Wild,
                PlayerRoster = playerRoster,
                EnemyMonsters = new IMonsterInstance[]
                {
                    // MonsterFactory builds a fully initialized instance:
                    // random IVs, nature, ability, moveset, shiny roll.
                    // (Full implementation in the MCE package.)
                    MonsterFactory.CreateWild(slot.Species, level)
                },
                Weather    = Weather.None,
                CanFlee    = true,
                CanCapture = true,
            };

            // 4. Start the battle. Async — resolves when battle ends.
            // MCE handles the full loop: intro animation, turn selection,
            // move execution, HP drain, status, XP gain, level up, evolution.
            BattleResult result = await battleManager.StartBattle(config);

            // 5. Handle result.
            if (result.WasCapture)
                await dialogManager.ShowDialog("Gotcha! " + result.CapturedMonster.Species.Name + " was caught!");
            else if (result.PlayerWon)
                await dialogManager.ShowDialog("You won! Gained " + result.ExperienceGained + " EXP.");
            else if (result.PlayerFled)
                await dialogManager.ShowDialog("Got away safely!");
            // else: player lost — MCE auto-handles whiteout via GameOverHandler.
        }
    }

    /// <summary>
    /// Stub factory for the sample. The real MonsterFactory handles IVs,
    /// EVs, nature, ability, moveset, shiny, and form logic.
    /// </summary>
    public static class MonsterFactory
    {
        public static IMonsterInstance CreateWild(IMonsterSpecies species, int level)
        {
            throw new System.NotImplementedException(
                "Install the MCE package from https://www.openmon.io");
        }
    }
}
