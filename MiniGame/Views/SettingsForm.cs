using System;
using System.Windows.Forms;
using WinFormsGame.Models;

namespace WinFormsGame.Views
{
    public partial class SettingsForm : Form
    {
        public string PlayerName => txtName.Text.Trim();
        public int PlayerHp => (int)numPlayerHp.Value;
        public int PlayerDamage => (int)numPlayerDamage.Value;
        public float PlayerSpeed => (float)numPlayerSpeed.Value;

        public DifficultyConfig UpdatedDifficultyConfig => new DifficultyConfig
        {
            MaxMonsters = (int)numMonsterCount.Value,
            MonsterHealth = (int)numMonsterHp.Value,
            MonsterDamage = (int)numMonsterDamage.Value,
            MonsterSpeed = (float)numMonsterSpeed.Value,
            MonsterVisionRadius = (float)numMonsterVision.Value,
            PeacefulMode = false
        };

        public SettingsForm(PlayerEntity player, DifficultyConfig config, bool isPeaceful)
        {
            InitializeComponent();

            txtName.Text = player.Name;

            numPlayerHp.Minimum = 1; numPlayerHp.Maximum = 999; numPlayerHp.Value = player.MaxHealth;
            numPlayerDamage.Minimum = 1; numPlayerDamage.Maximum = 99; numPlayerDamage.Value = player.AttackPower;
            numPlayerSpeed.DecimalPlaces = 1; numPlayerSpeed.Increment = 0.1M; numPlayerSpeed.Minimum = 1; numPlayerSpeed.Maximum = 20; numPlayerSpeed.Value = (decimal)player.Speed;

            numMonsterCount.Minimum = 0; numMonsterCount.Maximum = 100; numMonsterCount.Value = config.MaxMonsters;
            numMonsterHp.Minimum = 1; numMonsterHp.Maximum = 999; numMonsterHp.Value = Math.Max(1, config.MonsterHealth);
            numMonsterDamage.Minimum = 1; numMonsterDamage.Maximum = 99; numMonsterDamage.Value = Math.Max(1, config.MonsterDamage);
            numMonsterSpeed.DecimalPlaces = 1; numMonsterSpeed.Increment = 0.1M; numMonsterSpeed.Minimum = 0.5M; numMonsterSpeed.Maximum = 20; numMonsterSpeed.Value = Math.Max(0.5M, (decimal)config.MonsterSpeed);
            numMonsterVision.Minimum = 10; numMonsterVision.Maximum = 600; numMonsterVision.Value = Math.Max(10, (decimal)config.MonsterVisionRadius);

            if (isPeaceful)
            {
                numMonsterCount.Value = 0;
                numMonsterCount.Enabled = false;
                numMonsterHp.Enabled = false;
                numMonsterDamage.Enabled = false;
                numMonsterSpeed.Enabled = false;
                numMonsterVision.Enabled = false;
            }
        }
    }
}
