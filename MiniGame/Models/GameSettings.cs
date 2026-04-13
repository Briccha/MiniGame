using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/GameSettings.cs
namespace WinFormsGame.Models
{
    public class GameSettings
    {
        public enum DifficultyLevel
        {
            Easy,
            Normal,
            Hard
        }

        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Normal;
        public float BaseSpeed { get; set; } = 5f;
        public float BoostMultiplier { get; set; } = 2.0f;
        public int InitialItemCount { get; set; } = 10;
        public int MinItemsOnMap { get; set; } = 5;
        public float CoinSpawnChance { get; set; } = 0.8f;

        public void ApplyDifficulty(DifficultyLevel level)
        {
            Difficulty = level;
            switch (level)
            {
                case DifficultyLevel.Easy:
                    BaseSpeed = 6f;
                    InitialItemCount = 12;
                    MinItemsOnMap = 7;
                    CoinSpawnChance = 0.9f;
                    break;
                case DifficultyLevel.Normal:
                    BaseSpeed = 5f;
                    InitialItemCount = 10;
                    MinItemsOnMap = 5;
                    CoinSpawnChance = 0.8f;
                    break;
                case DifficultyLevel.Hard:
                    BaseSpeed = 4f;
                    InitialItemCount = 8;
                    MinItemsOnMap = 3;
                    CoinSpawnChance = 0.7f;
                    break;
            }
        }

        public float GetCurrentSpeed(bool isBoosting)
        {
            return isBoosting ? BaseSpeed * BoostMultiplier : BaseSpeed;
        }
    }
}
