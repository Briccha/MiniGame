using WinFormsGame.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsGame.Models;
using WinFormsGame.Presenters;
using WinFormsGame.Utilities;

namespace WinFormsGame
{
    public partial class MainForm : Form
    {
        private GamePresenter presenter;
        private GameSettings settings;
        private bool isUiOverlayOpen;
        private readonly ToolTip buttonToolTip = new ToolTip();

        public MainForm()
        {
            InitializeComponent();
            settings = new GameSettings();
            InitializeGame();
            ConfigureTooltips();
            BindEvents();
            ShowHelpForm();
        }

        private void ShowHelpForm()
        {
            isUiOverlayOpen = true;
            using (var helpForm = new HelpForm())
            {
                helpForm.ShowDialog();
            }
            isUiOverlayOpen = false;
        }

        private void InitializeGame()
        {
            var mapBounds = new Rectangle(0, 0, gameCanvas.Width, gameCanvas.Height);
            var model = new GameModel(mapBounds, settings);

            presenter = new GamePresenter(model, gameCanvas);
            gameCanvas.SetModel(model);
            gameCanvas.SetInputHandler(presenter.InputHandler);

            cmbTheme.SelectedIndex = 0;
            ApplyTheme(AppTheme.Light);

            cmbDifficulty.Items.Clear();
            cmbDifficulty.Items.AddRange(new object[] { "Мирный", "Легкий", "Средний", "Сложный" });
            cmbDifficulty.SelectedIndex = (int)GameSettings.DifficultyLevel.Medium;

            UpdateStats();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var level = (GameSettings.DifficultyLevel)cmbDifficulty.SelectedIndex;
            var currentConfig = settings.DifficultyConfigs[level];

            isUiOverlayOpen = true;
            using (var form = new SettingsForm(presenter.GetPlayer(), currentConfig, currentConfig.PeacefulMode))
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    isUiOverlayOpen = false;
                    return;
                }

                presenter.ApplyPlayerSettings(form.PlayerName, form.PlayerHp, form.PlayerDamage, form.PlayerSpeed);
                if (!currentConfig.PeacefulMode)
                {
                    settings.UpdateDifficultyConfig(level, form.UpdatedDifficultyConfig);
                }
                presenter.ApplySettings(settings);
                UpdateStats();
            }
            isUiOverlayOpen = false;
        }

        private void CmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settings == null) return;
            settings.ApplyDifficulty((GameSettings.DifficultyLevel)cmbDifficulty.SelectedIndex);
            presenter?.ApplySettings(settings);
            UpdateStats();
        }

        private void BtnHelp_Click(object sender, EventArgs e) => ShowHelpForm();

        private void BindEvents()
        {
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            Resize += MainForm_Resize;

            presenter.ScoreChanged += (s, e) => UpdateStats();
            presenter.PlayerStateChanged += (s, e) => UpdateStats();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) => presenter.HandleKeyDown(e);
        private void MainForm_KeyUp(object sender, KeyEventArgs e) => presenter.HandleKeyUp(e);
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isUiOverlayOpen || cmbTheme.DroppedDown || cmbDifficulty.DroppedDown)
            {
                return;
            }
            presenter.Update();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            presenter?.UpdateMapBounds(new Rectangle(0, 0, gameCanvas.Width, gameCanvas.Height));
        }

        private void UpdateStats()
        {
            lblBalanceValue.Text = presenter.GetPlayerBalance().ToString();
            if (lblHpValue != null)
            {
                var player = presenter.GetPlayer();
                lblHpValue.Text = $"{player.Health}/{player.MaxHealth}";
            }
        }

        private void BtnShop_Click(object sender, EventArgs e)
        {
            isUiOverlayOpen = true;
            using (var shopForm = new ShopForm(presenter.GetPlayer()))
            {
                if (shopForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateStats();
                    gameCanvas.Invalidate();
                }
            }
            isUiOverlayOpen = false;
        }


        private string ShowInputDialog(string prompt, string title, string defaultValue)
        {
            using (var form = new Form())
            using (var lbl = new Label())
            using (var txt = new TextBox())
            using (var btnOk = new Button())
            using (var btnCancel = new Button())
            {
                form.Text = title;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(400, 120);
                form.MinimizeBox = false;
                form.MaximizeBox = false;

                lbl.Text = prompt;
                lbl.SetBounds(9, 10, 380, 20);

                txt.Text = defaultValue ?? string.Empty;
                txt.SetBounds(12, 35, 376, 23);

                btnOk.Text = "OK";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.SetBounds(220, 70, 80, 25);

                btnCancel.Text = "Отмена";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.SetBounds(305, 70, 80, 25);

                form.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                return form.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
            }
        }

        private void CmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppTheme theme = (AppTheme)cmbTheme.SelectedIndex;
            ApplyTheme(theme);
        }

        private void ConfigureTooltips()
        {
            buttonToolTip.SetToolTip(btnShop, "Открыть магазин скинов");

            buttonToolTip.SetToolTip(btnSettings, "Открыть настройки сложности и персонажа");
            buttonToolTip.SetToolTip(btnHelp, "Показать справку");
        }

        private void ApplyTheme(AppTheme theme)
        {
            ThemeManager.ApplyTheme(this, theme);
            ThemeManager.ApplyTheme(topPanel, theme);
            var found = Controls.Find("instructionPanel", true);
            if (found.Length > 0)
            {
                ThemeManager.ApplyTheme(found[0], theme);
            }
        }

        private void lblDifficulty_Click(object sender, EventArgs e)
        {

        }
    }
}
