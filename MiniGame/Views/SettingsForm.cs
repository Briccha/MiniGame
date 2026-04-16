using System;
using System.Windows.Forms;
using WinFormsGame.Models;

namespace WinFormsGame.Views
{
    public partial class SettingsForm : Form
    {
        private readonly string initialPlayerName;
        private readonly int initialPlayerHp;
        private readonly int initialPlayerDamage;
        private readonly float initialPlayerSpeed;
        private readonly DifficultyConfig initialConfig;
        private bool settingsApplied;

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
            initialConfig = new DifficultyConfig
            {
                MaxMonsters = config.MaxMonsters,
                MonsterHealth = config.MonsterHealth,
                MonsterDamage = config.MonsterDamage,
                MonsterSpeed = config.MonsterSpeed,
                MonsterVisionRadius = config.MonsterVisionRadius,
                PeacefulMode = config.PeacefulMode
            };

            txtName.Text = player.Name;
            initialPlayerName = player.Name;

            numPlayerHp.Value = player.MaxHealth;
            initialPlayerHp = player.MaxHealth;
            numPlayerDamage.Value = player.AttackPower;
            initialPlayerDamage = player.AttackPower;
            numPlayerSpeed.Value = (decimal)player.Speed;
            initialPlayerSpeed = player.Speed;

            numMonsterCount.Value = config.MaxMonsters;
            numMonsterHp.Value = Math.Max(1, config.MonsterHealth);
            numMonsterDamage.Value = Math.Max(1, config.MonsterDamage);
            numMonsterSpeed.Value = Math.Max(0.5M, (decimal)config.MonsterSpeed);
            numMonsterVision.Value = Math.Max(10, (decimal)config.MonsterVisionRadius);

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            settingsApplied = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settingsApplied || !HasPendingChanges())
            {
                return;
            }

            var result = MessageBox.Show(
                "Есть несохраненные изменения. Закрыть без применения?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private bool HasPendingChanges()
        {
            if (!string.Equals(PlayerName, initialPlayerName, StringComparison.Ordinal))
            {
                return true;
            }

            if (PlayerHp != initialPlayerHp || PlayerDamage != initialPlayerDamage || Math.Abs(PlayerSpeed - initialPlayerSpeed) > 0.001f)
            {
                return true;
            }

            return UpdatedDifficultyConfig.MaxMonsters != initialConfig.MaxMonsters
                   || UpdatedDifficultyConfig.MonsterHealth != initialConfig.MonsterHealth
                   || UpdatedDifficultyConfig.MonsterDamage != initialConfig.MonsterDamage
                   || Math.Abs(UpdatedDifficultyConfig.MonsterSpeed - initialConfig.MonsterSpeed) > 0.001f
                   || Math.Abs(UpdatedDifficultyConfig.MonsterVisionRadius - initialConfig.MonsterVisionRadius) > 0.001f;
        }
    }
}
