using WinFormsGame.Views;

namespace WinFormsGame
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBalanceValue;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Label lblTheme;
        //private System.Windows.Forms.Panel instructionPanel;
        //private System.Windows.Forms.Label lblInstructionTitle;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblHp;
        private System.Windows.Forms.Label lblHpValue;
        private System.Windows.Forms.Label lblMouseInstruction;
        private System.Windows.Forms.Label lblKeyboardInstruction;
        private System.Windows.Forms.Label lblCollectiblesInstruction;
        private GameCanvas gameCanvas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblBalanceValue = new System.Windows.Forms.Label();
            this.btnShop = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblHp = new System.Windows.Forms.Label();
            this.lblHpValue = new System.Windows.Forms.Label();
            this.lblMouseInstruction = new System.Windows.Forms.Label();
            this.lblKeyboardInstruction = new System.Windows.Forms.Label();
            this.lblCollectiblesInstruction = new System.Windows.Forms.Label();
            this.gameCanvas = new WinFormsGame.Views.GameCanvas();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 16;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.topPanel.Controls.Add(this.lblBalance);
            this.topPanel.Controls.Add(this.lblBalanceValue);
            this.topPanel.Controls.Add(this.btnShop);
            this.topPanel.Controls.Add(this.btnName);
            this.topPanel.Controls.Add(this.cmbTheme);
            this.topPanel.Controls.Add(this.lblTheme);
            this.topPanel.Controls.Add(this.lblDifficulty);
            this.topPanel.Controls.Add(this.cmbDifficulty);
            this.topPanel.Controls.Add(this.btnHelp);
            this.topPanel.Controls.Add(this.btnSettings);
            this.topPanel.Controls.Add(this.lblHp);
            this.topPanel.Controls.Add(this.lblHpValue);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(978, 41);
            this.topPanel.TabIndex = 0;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(9, 11);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(78, 21);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Монеты:";
            // 
            // lblBalanceValue
            // 
            this.lblBalanceValue.AutoSize = true;
            this.lblBalanceValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBalanceValue.Location = new System.Drawing.Point(91, 12);
            this.lblBalanceValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBalanceValue.Name = "lblBalanceValue";
            this.lblBalanceValue.Size = new System.Drawing.Size(19, 21);
            this.lblBalanceValue.TabIndex = 1;
            this.lblBalanceValue.Text = "0";
            // 
            // btnShop
            // 
            this.btnShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShop.Location = new System.Drawing.Point(250, 6);
            this.btnShop.Margin = new System.Windows.Forms.Padding(2);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(104, 29);
            this.btnShop.TabIndex = 4;
            this.btnShop.Text = "🛒 Магазин";
            this.btnShop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShop.UseVisualStyleBackColor = true;
            // 
            // btnName
            // 
            this.btnName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnName.Location = new System.Drawing.Point(358, 7);
            this.btnName.Margin = new System.Windows.Forms.Padding(2);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(74, 29);
            this.btnName.TabIndex = 5;
            this.btnName.Text = "✏️ Имя";
            this.btnName.UseVisualStyleBackColor = true;
            // 
            // cmbTheme
            // 
            this.cmbTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Items.AddRange(new object[] {
            "Светлая",
            "Темная",
            "Системная"});
            this.cmbTheme.Location = new System.Drawing.Point(799, 9);
            this.cmbTheme.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(91, 25);
            this.cmbTheme.TabIndex = 6;
            // 
            // lblTheme
            // 
            this.lblTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTheme.AutoSize = true;
            this.lblTheme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTheme.Location = new System.Drawing.Point(752, 12);
            this.lblTheme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(43, 19);
            this.lblTheme.TabIndex = 7;
            this.lblTheme.Text = "Тема:";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDifficulty.Location = new System.Drawing.Point(563, 13);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(81, 19);
            this.lblDifficulty.TabIndex = 6;
            this.lblDifficulty.Text = "Сложность:";
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDifficulty.Location = new System.Drawing.Point(648, 10);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(100, 25);
            this.cmbDifficulty.TabIndex = 7;
            this.cmbDifficulty.SelectedIndexChanged += new System.EventHandler(this.CmbDifficulty_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHelp.Location = new System.Drawing.Point(899, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 29);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "❓";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSettings.Location = new System.Drawing.Point(937, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(38, 30);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "⚙ Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // lblHp
            // 
            this.lblHp.AutoSize = true;
            this.lblHp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHp.Location = new System.Drawing.Point(120, 11);
            this.lblHp.Name = "lblHp";
            this.lblHp.Size = new System.Drawing.Size(36, 21);
            this.lblHp.TabIndex = 2;
            this.lblHp.Text = "HP:";
            // 
            // lblHpValue
            // 
            this.lblHpValue.AutoSize = true;
            this.lblHpValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHpValue.Location = new System.Drawing.Point(159, 12);
            this.lblHpValue.Name = "lblHpValue";
            this.lblHpValue.Size = new System.Drawing.Size(34, 21);
            this.lblHpValue.TabIndex = 3;
            this.lblHpValue.Text = "0/0";
            // 
            // lblMouseInstruction
            // 
            this.lblMouseInstruction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMouseInstruction.Location = new System.Drawing.Point(8, 41);
            this.lblMouseInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMouseInstruction.Name = "lblMouseInstruction";
            this.lblMouseInstruction.Size = new System.Drawing.Size(172, 98);
            this.lblMouseInstruction.TabIndex = 1;
            this.lblMouseInstruction.Text = "🖱️ Мышь:\n• Клик ЛКМ - движение к точке\n• Зажать ЛКМ на персонаже - перенос";
            // 
            // lblKeyboardInstruction
            // 
            this.lblKeyboardInstruction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKeyboardInstruction.Location = new System.Drawing.Point(8, 146);
            this.lblKeyboardInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKeyboardInstruction.Name = "lblKeyboardInstruction";
            this.lblKeyboardInstruction.Size = new System.Drawing.Size(172, 65);
            this.lblKeyboardInstruction.TabIndex = 2;
            this.lblKeyboardInstruction.Text = "⌨️ Клавиатура:\n• WASD - движение";
            // 
            // lblCollectiblesInstruction
            // 
            this.lblCollectiblesInstruction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCollectiblesInstruction.Location = new System.Drawing.Point(8, 219);
            this.lblCollectiblesInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCollectiblesInstruction.Name = "lblCollectiblesInstruction";
            this.lblCollectiblesInstruction.Size = new System.Drawing.Size(172, 65);
            this.lblCollectiblesInstruction.TabIndex = 3;
            this.lblCollectiblesInstruction.Text = "💎 Предметы:\n• 🟡 Монета = 1\n• 🔵 Кристалл = 5";
            // 
            // gameCanvas
            // 
            this.gameCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gameCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameCanvas.Location = new System.Drawing.Point(0, 41);
            this.gameCanvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(978, 447);
            this.gameCanvas.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 488);
            this.Controls.Add(this.gameCanvas);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(604, 414);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catch them all";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
