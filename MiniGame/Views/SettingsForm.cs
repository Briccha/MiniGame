using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsGame.Models;

namespace WinFormsGame.Views
{
    public class SettingsForm : Form
    {
        private readonly TextBox txtName = new TextBox();
        private readonly NumericUpDown numPlayerHp = new NumericUpDown();
        private readonly NumericUpDown numPlayerDamage = new NumericUpDown();
        private readonly NumericUpDown numPlayerSpeed = new NumericUpDown();
        private readonly NumericUpDown numMonsterCount = new NumericUpDown();
        private readonly NumericUpDown numMonsterHp = new NumericUpDown();
        private readonly NumericUpDown numMonsterDamage = new NumericUpDown();
        private readonly NumericUpDown numMonsterSpeed = new NumericUpDown();
        private readonly NumericUpDown numMonsterVision = new NumericUpDown();

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
            Text = "Настройки игры";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(360, 430);

            int y = 15;
            AddLabel("Игрок", y, true); y += 32;
            AddRow("Никнейм", txtName, ref y);
            txtName.Text = player.Name;

            numPlayerHp.Minimum = 1; numPlayerHp.Maximum = 999; numPlayerHp.Value = player.MaxHealth;
            AddRow("ХП", numPlayerHp, ref y);

            numPlayerDamage.Minimum = 1; numPlayerDamage.Maximum = 99; numPlayerDamage.Value = player.AttackPower;
            AddRow("Урон", numPlayerDamage, ref y);

            numPlayerSpeed.DecimalPlaces = 1; numPlayerSpeed.Increment = 0.1M; numPlayerSpeed.Minimum = 1; numPlayerSpeed.Maximum = 20; numPlayerSpeed.Value = (decimal)player.Speed;
            AddRow("Скорость", numPlayerSpeed, ref y);

            y += 6;
            AddLabel("Текущая сложность", y, true); y += 32;

            numMonsterCount.Minimum = 0; numMonsterCount.Maximum = 100; numMonsterCount.Value = config.MaxMonsters;
            AddRow("Монстры", numMonsterCount, ref y);

            numMonsterHp.Minimum = 1; numMonsterHp.Maximum = 999; numMonsterHp.Value = Math.Max(1, config.MonsterHealth);
            AddRow("ХП монстра", numMonsterHp, ref y);

            numMonsterDamage.Minimum = 1; numMonsterDamage.Maximum = 99; numMonsterDamage.Value = Math.Max(1, config.MonsterDamage);
            AddRow("Урон монстра", numMonsterDamage, ref y);

            numMonsterSpeed.DecimalPlaces = 1; numMonsterSpeed.Increment = 0.1M; numMonsterSpeed.Minimum = 0.5M; numMonsterSpeed.Maximum = 20; numMonsterSpeed.Value = Math.Max(0.5M, (decimal)config.MonsterSpeed);
            AddRow("Скорость монстра", numMonsterSpeed, ref y);

            numMonsterVision.Minimum = 10; numMonsterVision.Maximum = 600; numMonsterVision.Value = Math.Max(10, (decimal)config.MonsterVisionRadius);
            AddRow("Радиус зрения", numMonsterVision, ref y);

            if (isPeaceful)
            {
                numMonsterCount.Value = 0;
                numMonsterCount.Enabled = false;
                numMonsterHp.Enabled = false;
                numMonsterDamage.Enabled = false;
                numMonsterSpeed.Enabled = false;
                numMonsterVision.Enabled = false;
            }

            var btnSave = new Button { Text = "Сохранить", DialogResult = DialogResult.OK, FlatStyle = FlatStyle.Flat, Width = 110, Height = 30, Location = new Point(130, 385) };
            Controls.Add(btnSave);
            AcceptButton = btnSave;
        }

        private void AddLabel(string text, int y, bool bold)
        {
            Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", bold ? 10 : 9, bold ? FontStyle.Bold : FontStyle.Regular),
                Left = 20,
                Top = y,
                Width = 300
            });
        }

        private void AddRow(string title, Control control, ref int y)
        {
            AddLabel(title, y + 4, false);
            control.Left = 170;
            control.Top = y;
            control.Width = 160;
            Controls.Add(control);
            y += 34;
        }
    }
}
