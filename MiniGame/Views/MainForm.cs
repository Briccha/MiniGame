using WinFormsGame.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsGame.Models;
using WinFormsGame.Presenters;
using WinFormsGame.Utilities;

namespace WinFormsGame
{
    // Views/MainForm.cs (изменения)
    public partial class MainForm : Form
    {
        private GamePresenter presenter;
        private GameSettings settings;

        public MainForm()
        {
            InitializeComponent();
            settings = new GameSettings();
            InitializeGame();
            BindEvents();
            ShowHelpForm();
        }

        private void ShowHelpForm()
        {
            using (var helpForm = new HelpForm())
            {
                if (helpForm.ShowDialog() == DialogResult.OK)
                {
                    // Persisting the "show on startup" setting is omitted because
                    // the project does not include a Settings file. If you add
                    // application settings later, restore saving here.
                }
            }
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

            // Инициализация выпадающего списка сложности
            cmbDifficulty.Items.Clear();
            cmbDifficulty.Items.AddRange(new object[] { "Легко", "Нормально", "Сложно" });
            cmbDifficulty.SelectedIndex = 1;

            UpdateBalance();
        }

        private void CmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settings == null) return;
            settings.ApplyDifficulty((GameSettings.DifficultyLevel)cmbDifficulty.SelectedIndex);
            presenter?.ApplySettings(settings);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            ShowHelpForm();
        }

        private void BindEvents()
        {
            // События формы
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += MainForm_KeyUp;
            this.Resize += MainForm_Resize;

            // События таймера
            gameTimer.Tick += GameTimer_Tick;

            // События кнопок
            btnShop.Click += BtnShop_Click;
            btnName.Click += BtnName_Click;
            cmbTheme.SelectedIndexChanged += CmbTheme_SelectedIndexChanged;

            // События презентера
            presenter.ScoreChanged += (s, e) => UpdateBalance();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            presenter.HandleKeyDown(e);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            presenter.HandleKeyUp(e);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            presenter.Update();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Обновляем границы карты при изменении размера
            if (presenter != null)
            {
                presenter.UpdateMapBounds(new Rectangle(0, 0, gameCanvas.Width, gameCanvas.Height));
            }
        }

        private void UpdateBalance()
        {
            lblBalanceValue.Text = presenter.GetPlayerBalance().ToString();
        }

        private void BtnShop_Click(object sender, EventArgs e)
        {
            using (var shopForm = new ShopForm(presenter.GetPlayer()))
            {
                if (shopForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateBalance();
                    gameCanvas.Invalidate();
                }
            }
        }

        private void BtnName_Click(object sender, EventArgs e)
        {
            string newName = ShowInputDialog("Введите имя персонажа:", "Изменение имени", presenter.GetPlayerName());

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

        private void ApplyTheme(AppTheme theme)
        {
            ThemeManager.ApplyTheme(this, theme);
            ThemeManager.ApplyTheme(topPanel, theme);
            // instructionPanel may be commented out in the designer; apply theme
            // to it only if it exists in the controls collection.
            var found = this.Controls.Find("instructionPanel", true);
            if (found.Length > 0)
            {
                ThemeManager.ApplyTheme(found[0], theme);
            }
        }
    }
}