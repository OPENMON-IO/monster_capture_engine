// =============================================================================
// OpenMon — Monster Capture Engine | Public API Surface
// =============================================================================
//
// This file defines the PUBLIC interfaces, enums, and contracts of MCE.
// The full implementation (90,000+ lines, 2,344+ tests) is available via
// the MCE Unity package. Visit https://www.openmon.io for licensing.
//
// Copyright (c) 2024-2026 OpenMon.IO. All rights reserved.
// See LICENSE file for usage terms.
// =============================================================================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenMon.MCE
{
    // =========================================================================
    // BATTLE SYSTEM
    // =========================================================================

    public interface IBattleManager
    {
        bool IsInBattle { get; }
        BattleState CurrentState { get; }
        int Turn { get; }
        BattleType BattleType { get; }
        Task<BattleResult> StartBattle(BattleConfig config);
        Task ExecuteMove(IBattler source, int moveSlot, IBattler target = null);
        Task<CaptureResult> AttemptCapture(IItemInstance ball, IBattler target);
        Task SwitchBattler(int rosterSlot);
        Task<bool> AttemptFlee();
        event Action<int> OnTurnStart;
        event Action<BattleResult> OnBattleEnd;
    }

    public interface IBattler
    {
        IMonsterInstance Monster { get; }
        bool IsFainted { get; }
        int CurrentHP { get; }
        int MaxHP { get; }
        Dictionary<Stat, int> StatStages { get; }
        IReadOnlyList<VolatileStatus> VolatileStatuses { get; }
        bool IsPlayerOwned { get; }
    }

    public interface IBattleModule
    {
        string ModuleName { get; }
        void OnBattleStart(IBattleManager manager);
        void OnBattleEnd(BattleResult result);
        void OnTurnStart(int turn);
    }

    // =========================================================================
    // MONSTER DATA
    // =========================================================================

    public interface IMonsterInstance
    {
        IMonsterSpecies Species { get; }
        int Level { get; }
        int CurrentHP { get; set; }
        int MaxHP { get; }
        int GetStat(Stat stat);
        IReadOnlyList<IMove> Moves { get; }
        IAbility Ability { get; }
        StatusCondition Status { get; set; }
        Nature Nature { get; }
        IReadOnlyDictionary<Stat, int> IVs { get; }
        IReadOnlyDictionary<Stat, int> EVs { get; }
        int FormIndex { get; }
        int Friendship { get; set; }
        bool IsShiny { get; }
        IItemInstance HeldItem { get; set; }
        string OriginalTrainer { get; }
        int Experience { get; }
        bool CanEvolve(out IEvolutionMethod method);
    }

    public interface IMonsterSpecies
    {
        int DexNumber { get; }
        string Name { get; }
        MonsterType PrimaryType { get; }
        MonsterType? SecondaryType { get; }
        IReadOnlyDictionary<Stat, int> BaseStats { get; }
        IReadOnlyList<IAbility> PossibleAbilities { get; }
        IAbility HiddenAbility { get; }
        IReadOnlyList<IEvolutionMethod> Evolutions { get; }
        float CatchRate { get; }
        float GenderRatio { get; }
        int BaseExperienceYield { get; }
        IReadOnlyList<EggGroup> EggGroups { get; }
    }

    // =========================================================================
    // ROSTER AND STORAGE
    // =========================================================================

    public interface IRoster
    {
        int Count { get; }
        int MaxSize { get; }
        IMonsterInstance this[int index] { get; }
        bool Add(IMonsterInstance monster);
        bool Remove(int index);
        void Swap(int indexA, int indexB);
        IMonsterInstance GetFirstNonFainted();
        IEnumerator<IMonsterInstance> GetEnumerator();
    }

    // =========================================================================
    // WORLD SYSTEM
    // =========================================================================

    public interface IWorldManager
    {
        string CurrentScene { get; }
        UnityEngine.Vector3Int PlayerPosition { get; }
        Direction PlayerFacing { get; }
        bool IsPlayerMoving { get; }
        Task TeleportPlayer(string sceneName, UnityEngine.Vector2Int position);
        bool IsTileWalkable(UnityEngine.Vector3Int position);
        IEncounterData GetEncounterData(UnityEngine.Vector3Int position);
        event Action<string> OnSceneChanged;
    }

    // =========================================================================
    // DIALOG SYSTEM
    // =========================================================================

    public interface IDialogManager
    {
        bool IsDialogActive { get; }
        Task ShowDialog(string text, bool waitForInput = true);
        Task<int> ShowChoice(string prompt, string[] options);
        Task<string> ShowTextInput(string prompt, int maxLength = 12);
    }

    // =========================================================================
    // INPUT SYSTEM
    // =========================================================================

    public interface IInputManager
    {
        string CurrentReceiverName { get; }
        void RequestInput(IInputReceiver receiver);
        void ReleaseInput(IInputReceiver receiver);
    }

    public interface IInputReceiver
    {
        string GetDebugName();
        InputType GetInputType();
    }

    // =========================================================================
    // SAVE SYSTEM
    // =========================================================================

    public interface ISaveManager
    {
        bool HasSavegames { get; }
        Task Save(int slot = 0);
        Task Load(int slot = 0);
        void Delete(int slot);
        IReadOnlyList<SaveSlotInfo> GetSlotInfos();
    }

    // =========================================================================
    // ONLINE (OPTIONAL — Nakama MMORPG layer, MCE_ONLINE define)
    // =========================================================================

    public interface IOnlineManager
    {
        bool IsConnected { get; }
        Task<bool> Connect(string serverUrl, string apiKey);
        Task<bool> Authenticate(string username, string password);
        Task StartPvPMatch(PvPConfig config);
        Task SyncWorldState();
    }

    // =========================================================================
    // ITEM, MOVE, ABILITY, EVOLUTION stubs
    // =========================================================================

    public interface IMove
    {
        string Name { get; }
        MonsterType Type { get; }
        MoveCategory Category { get; }
        int Power { get; }
        int Accuracy { get; }
        int PP { get; }
        int CurrentPP { get; set; }
    }

    public interface IAbility { string Name { get; } string Description { get; } }
    public interface IItemInstance { string Name { get; } int Count { get; set; } }
    public interface IEvolutionMethod { string MethodType { get; } IMonsterSpecies TargetSpecies { get; } bool CanEvolve(IMonsterInstance monster); }
    public interface IEncounterData { IReadOnlyList<EncounterSlot> Slots { get; } }
}

namespace OpenMon.MCE.Data
{
    // =========================================================================
    // ENUMS
    // =========================================================================

    public enum MonsterType { Normal, Fire, Water, Grass, Electric, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon, Dark, Steel, Fairy }
    public enum Stat { HP, Attack, Defense, SpecialAttack, SpecialDefense, Speed, Accuracy, Evasion }
    public enum BattleState { NotInBattle, Intro, ActionSelection, MoveSelection, TargetSelection, TurnExecution, TurnResolution, BattleEnd, ExperienceGain, LevelUp, Evolution }
    public enum MoveCategory { Physical, Special, Status }
    public enum BattleType { Wild, Trainer, Double, Multi, Horde, Raid }
    public enum StatusCondition { None, Burn, Freeze, Paralysis, Poison, BadlyPoisoned, Sleep }
    public enum VolatileStatus { Confusion, Infatuation, Flinch, LeechSeed, Substitute, Taunt, Torment, Encore, Disable, Curse, Nightmare, PerishSong, Yawn, Trapped }
    public enum Weather { None, HarshSunlight, Rain, Sandstorm, Hail, Fog, Snow, StrongWinds }
    public enum Nature { Hardy, Lonely, Brave, Adamant, Naughty, Bold, Docile, Relaxed, Impish, Lax, Timid, Hasty, Serious, Jolly, Naive, Modest, Mild, Quiet, Bashful, Rash, Calm, Gentle, Sassy, Careful, Quirky }
    public enum Direction { None, Up, Down, Left, Right }
    public enum InputType { Player, UI, Battle, Dialog, Cutscene }
    public enum EggGroup { Monster, Water1, Water2, Water3, Bug, Flying, Field, Fairy, Grass, HumanLike, Mineral, Amorphous, Dragon, Ditto, Undiscovered }

    // =========================================================================
    // STRUCTS
    // =========================================================================

    [System.Serializable]
    public struct BattleConfig
    {
        public BattleType Type;
        public OpenMon.MCE.IRoster PlayerRoster;
        public OpenMon.MCE.IMonsterInstance[] EnemyMonsters;
        public Weather Weather;
        public string TrainerName;
        public string TrainerClass;
        public int TrainerRewardMoney;
        public bool CanFlee;
        public bool CanCapture;
    }

    [System.Serializable]
    public struct BattleResult
    {
        public bool PlayerWon;
        public bool PlayerFled;
        public bool WasCapture;
        public int ExperienceGained;
        public int MoneyGained;
        public OpenMon.MCE.IMonsterInstance CapturedMonster;
        public int TurnsElapsed;
    }

    [System.Serializable]
    public struct CaptureResult { public bool Success; public int ShakeCount; public bool IsCriticalCapture; }

    [System.Serializable]
    public struct SaveSlotInfo { public int Slot; public string PlayerName; public int BadgeCount; public int DexCount; public System.TimeSpan PlayTime; public System.DateTime LastSaved; public string Location; }

    [System.Serializable]
    public struct PvPConfig { public BattleType Format; public int MaxLevel; public int TeamSize; public bool RankedMode; }

    [System.Serializable]
    public struct EncounterSlot { public OpenMon.MCE.IMonsterSpecies Species; public int MinLevel; public int MaxLevel; public float Weight; }
}
