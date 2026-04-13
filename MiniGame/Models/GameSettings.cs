using System.Collections.Generic;

namespace WinFormsGame.Models
{
    public class DifficultyConfig
    {
        public int MaxMonsters { get; set; }
        public int MonsterHealth { get; set; }
        public int MonsterDamage { get; set; }
        public float MonsterSpeed { get; set; }
        public float MonsterVisionRadius { get; set; }
        public bool PeacefulMode { get; set; }
    }

    public class GameSettings
    {
        public enum DifficultyLevel
        {
            Peaceful,
            Easy,
            Medium,
            Hard
        }

        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Medium;

        public float BaseSpeed { get; set; } = 5f;
        public float BoostMultiplier { get; set; } = 2.0f;
        public int MinItemsOnMap { get; set; } = 6;
        public float CrystalDropChance { get; set; } = 0.18f;

        public Dictionary<DifficultyLevel, DifficultyConfig> DifficultyConfigs { get; } = new Dictionary<DifficultyLevel, DifficultyConfig>
        {
            [DifficultyLevel.Peaceful] = new DifficultyConfig { PeacefulMode = true, MaxMonsters = 0, MonsterHealth = 0, MonsterDamage = 0, MonsterSpeed = 0f, MonsterVisionRadius = 0f },
            [DifficultyLevel.Easy] = new DifficultyConfig { MaxMonsters = 5, MonsterHealth = 10, MonsterDamage = 1, MonsterSpeed = 2.5f, MonsterVisionRadius = 140f },
            [DifficultyLevel.Medium] = new DifficultyConfig { MaxMonsters = 10, MonsterHealth = 20, MonsterDamage = 3, MonsterSpeed = 3.2f, MonsterVisionRadius = 180f },
            [DifficultyLevel.Hard] = new DifficultyConfig { MaxMonsters = 15, MonsterHealth = 50, MonsterDamage = 5, MonsterSpeed = 4.0f, MonsterVisionRadius = 220f },
        };

        public DifficultyConfig CurrentDifficultyConfig => DifficultyConfigs[Difficulty];

        public void ApplyDifficulty(DifficultyLevel level)
        {
            Difficulty = level;
        }

        public void UpdateDifficultyConfig(DifficultyLevel level, DifficultyConfig config)
        {
            DifficultyConfigs[level] = config;
        }

        public float GetCurrentSpeed(bool isBoosting)
        {
            return isBoosting ? BaseSpeed * BoostMultiplier : BaseSpeed;
        }
    }
}
