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
            //this.instructionPanel = new System.Windows.Forms.Panel();
            //this.lblInstructionTitle = new System.Windows.Forms.Label();
            this.lblMouseInstruction = new System.Windows.Forms.Label();
            this.lblKeyboardInstruction = new System.Windows.Forms.Label();
            this.lblCollectiblesInstruction = new System.Windows.Forms.Label();
            this.gameCanvas = new WinFormsGame.Views.GameCanvas();
            this.topPanel.SuspendLayout();
            //this.instructionPanel.SuspendLayout();
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
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(825, 41);
            this.topPanel.TabIndex = 0;
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
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
            //lblDifficulty
            //
            this.lblDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDifficulty.Location = new System.Drawing.Point(420, 12);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(75, 19);
            this.lblDifficulty.TabIndex = 6;
            this.lblDifficulty.Text = "Сложность:";
            //
            //cmbDifficulty
            //
            this.cmbDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDifficulty.Location = new System.Drawing.Point(500, 9);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(100, 25);
            this.cmbDifficulty.TabIndex = 7;
            //
            //btnHelp
            //
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHelp.Location = new System.Drawing.Point(610, 6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(60, 29);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "❓";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnShop
            // 
            this.btnShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShop.Location = new System.Drawing.Point(140, 6);
            this.btnShop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(104, 29);
            this.btnShop.TabIndex = 2;
            this.btnShop.Text = "🛒 Магазин";
            this.btnShop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShop.UseVisualStyleBackColor = true;
            // 
            // btnName
            // 
            this.btnName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnName.Location = new System.Drawing.Point(248, 6);
            this.btnName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(74, 29);
            this.btnName.TabIndex = 3;
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
            this.cmbTheme.Location = new System.Drawing.Point(727, 9);
            this.cmbTheme.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(91, 25);
            this.cmbTheme.TabIndex = 4;
            // 
            // lblTheme
            // 
            this.lblTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTheme.AutoSize = true;
            this.lblTheme.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTheme.Location = new System.Drawing.Point(680, 12);
            this.lblTheme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(43, 19);
            this.lblTheme.TabIndex = 5;
            this.lblTheme.Text = "Тема:";
            //// 
            //// instructionPanel
            //// 
            //this.instructionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            //this.instructionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.instructionPanel.Controls.Add(this.lblInstructionTitle);
            //this.instructionPanel.Controls.Add(this.lblMouseInstruction);
            //this.instructionPanel.Controls.Add(this.lblKeyboardInstruction);
            //this.instructionPanel.Controls.Add(this.lblCollectiblesInstruction);
            //this.instructionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            //this.instructionPanel.Location = new System.Drawing.Point(637, 41);
            //this.instructionPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            //this.instructionPanel.Name = "instructionPanel";
            //this.instructionPanel.Size = new System.Drawing.Size(188, 447);
            //this.instructionPanel.TabIndex = 1;
            //// 
            //// lblInstructionTitle
            //// 
            //this.lblInstructionTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            //this.lblInstructionTitle.Location = new System.Drawing.Point(8, 8);
            //this.lblInstructionTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            //this.lblInstructionTitle.Name = "lblInstructionTitle";
            //this.lblInstructionTitle.Size = new System.Drawing.Size(172, 24);
            //this.lblInstructionTitle.TabIndex = 0;
            //this.lblInstructionTitle.Text = "📖 Управление";
            //this.lblInstructionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gameCanvas.Size = new System.Drawing.Size(637, 447);
            this.gameCanvas.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.gameCanvas);
            //this.Controls.Add(this.instructionPanel);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(604, 414);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catch them all";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            //this.instructionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            this.cmbDifficulty.SelectedIndexChanged += new System.EventHandler(this.CmbDifficulty_SelectedIndexChanged);
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
        }
    }
}