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
        private Panel contentPanel;
        private Panel sidePanel;
        private Label lblQuickTitle;

        public MainForm()
        {
            InitializeComponent();
            ModernizeLayout();
            settings = new GameSettings();
            InitializeGame();
            ConfigureTooltips();
            BindEvents();
            ShowHelpForm();
        }

        private void ModernizeLayout()
        {
            SuspendLayout();

            Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);

            topPanel.Height = 76;
            topPanel.Padding = new Padding(12, 10, 12, 10);

            topPanel.Controls.Clear();

            var topLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48f));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52f));

            var statsFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = false,
                Padding = new Padding(4, 8, 4, 0)
            };

            lblBalance.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            lblBalanceValue.Font = new Font("Segoe UI", 11f, FontStyle.Regular);
            lblHp.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            lblHpValue.Font = new Font("Segoe UI", 11f, FontStyle.Regular);

            statsFlow.Controls.Add(lblBalance);
            statsFlow.Controls.Add(lblBalanceValue);
            statsFlow.Controls.Add(new Label { Width = 20 });
            statsFlow.Controls.Add(lblHp);
            statsFlow.Controls.Add(lblHpValue);

            var controlsLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            controlsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            controlsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            var quickActions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0, 0, 2, 0)
            };

            var systemActions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0, 2, 2, 0)
            };

            SetupTopButton(btnSettings, "⚙ Настройки", 120);
            SetupTopButton(btnHelp, "❓ Справка", 94);
            SetupTopButton(btnName, "✏ Имя", 90);
            SetupTopButton(btnShop, "🛒 Магазин", 112);

            quickActions.Controls.Add(btnSettings);
            quickActions.Controls.Add(btnHelp);
            quickActions.Controls.Add(btnName);
            quickActions.Controls.Add(btnShop);

            lblDifficulty.AutoSize = true;
            lblDifficulty.Margin = new Padding(12, 7, 4, 0);
            lblTheme.AutoSize = true;
            lblTheme.Margin = new Padding(12, 7, 4, 0);

            cmbDifficulty.Width = 126;
            cmbTheme.Width = 126;
            cmbDifficulty.Margin = new Padding(0, 3, 0, 0);
            cmbTheme.Margin = new Padding(0, 3, 0, 0);

            systemActions.Controls.Add(cmbTheme);
            systemActions.Controls.Add(lblTheme);
            systemActions.Controls.Add(cmbDifficulty);
            systemActions.Controls.Add(lblDifficulty);

            controlsLayout.Controls.Add(quickActions, 0, 0);
            controlsLayout.Controls.Add(systemActions, 0, 1);

            topLayout.Controls.Add(statsFlow, 0, 0);
            topLayout.Controls.Add(controlsLayout, 1, 0);
            topPanel.Controls.Add(topLayout);

            Controls.Remove(gameCanvas);
            contentPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 8, 12, 12) };
            sidePanel = new Panel { Dock = DockStyle.Left, Width = 252, Padding = new Padding(0, 0, 10, 0) };
            var sideCard = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12), BorderStyle = BorderStyle.FixedSingle };

            lblQuickTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 32,
                Text = "Быстрые подсказки",
                Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var tipsFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(0, 6, 0, 0)
            };

            ConfigureTipLabel(lblMouseInstruction, "🖱 Навигация\nЛКМ: перейти в точку\nПКМ: перетащить персонажа");
            ConfigureTipLabel(lblKeyboardInstruction, "⌨ Управление\nWASD: движение\nShift: ускорение");
            ConfigureTipLabel(lblCollectiblesInstruction, "💎 Лут\n🟡 Монета = 1\n🔵 Кристалл = 5");

            tipsFlow.Controls.Add(lblMouseInstruction);
            tipsFlow.Controls.Add(lblKeyboardInstruction);
            tipsFlow.Controls.Add(lblCollectiblesInstruction);

            sideCard.Controls.Add(tipsFlow);
            sideCard.Controls.Add(lblQuickTitle);
            sidePanel.Controls.Add(sideCard);

            gameCanvas.Dock = DockStyle.Fill;
            gameCanvas.Margin = new Padding(0);

            contentPanel.Controls.Add(gameCanvas);
            contentPanel.Controls.Add(sidePanel);
            Controls.Add(contentPanel);
            Controls.SetChildIndex(topPanel, 0);
            topPanel.BringToFront();

            ResumeLayout();
        }

        private void SetupTopButton(Button button, string text, int width)
        {
            button.Text = text;
            button.Width = width;
            button.Height = 30;
            button.AutoSize = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.Margin = new Padding(8, 1, 0, 0);
        }

        private void ConfigureTipLabel(Label label, string text)
        {
            label.Text = text;
            label.AutoSize = false;
            label.Width = 208;
            label.Height = 82;
            label.Margin = new Padding(0, 0, 0, 10);
            label.Padding = new Padding(10, 8, 10, 8);
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
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

        private void BtnName_Click(object sender, EventArgs e)
        {
            isUiOverlayOpen = true;
            string newName = ShowInputDialog("Введите имя персонажа:", "Изменение имени", presenter.GetPlayerName());
            isUiOverlayOpen = false;
            if (!string.IsNullOrWhiteSpace(newName))
            {
                presenter.SetPlayerName(newName);
                gameCanvas.Invalidate();
            }
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
            buttonToolTip.SetToolTip(btnName, "Изменить имя героя");
            buttonToolTip.SetToolTip(btnSettings, "Открыть настройки сложности и персонажа");
            buttonToolTip.SetToolTip(btnHelp, "Показать справку");
        }

        private void ApplyTheme(AppTheme theme)
        {
            var palette = ThemeManager.GetPalette(theme);
            ThemeManager.ApplyTheme(this, theme);
            ThemeManager.ApplyTheme(topPanel, theme);
            var found = Controls.Find("instructionPanel", true);
            if (found.Length > 0)
            {
                ThemeManager.ApplyTheme(found[0], theme);
            }

            if (contentPanel != null)
            {
                contentPanel.BackColor = palette.BackColor;
            }

            if (sidePanel != null)
            {
                sidePanel.BackColor = palette.BackColor;
            }

            if (lblQuickTitle != null)
            {
                lblQuickTitle.ForeColor = palette.ForeColor;
            }

            foreach (var label in new[] { lblMouseInstruction, lblKeyboardInstruction, lblCollectiblesInstruction })
            {
                label.BackColor = palette.SurfaceColor;
                label.ForeColor = palette.ForeColor;
            }

            gameCanvas.ApplyVisualTheme(palette);
            presenter?.SetUiSurfaceColor(palette.SurfaceColor);
            presenter?.SetUiDamageFlashColor(palette.DamageFlashColor);
        }
    }
}
