// Views/HelpForm.Designer.cs
namespace WinFormsGame.Views
{
    partial class HelpForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grpMouse;
        private System.Windows.Forms.Label lblMouseInfo;
        private System.Windows.Forms.GroupBox grpKeyboard;
        private System.Windows.Forms.Label lblKeyboardInfo;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.Label lblItemsInfo;
        private System.Windows.Forms.GroupBox grpBoost;
        private System.Windows.Forms.Label lblBoostInfo;
        private System.Windows.Forms.GroupBox grpShop;
        private System.Windows.Forms.Label lblShopInfo;
        private System.Windows.Forms.GroupBox grpDifficulty;
        private System.Windows.Forms.Label lblDifficultyInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkShowOnStartup;

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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpMouse = new System.Windows.Forms.GroupBox();
            this.lblMouseInfo = new System.Windows.Forms.Label();
            this.grpKeyboard = new System.Windows.Forms.GroupBox();
            this.lblKeyboardInfo = new System.Windows.Forms.Label();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.lblItemsInfo = new System.Windows.Forms.Label();
            this.grpBoost = new System.Windows.Forms.GroupBox();
            this.lblBoostInfo = new System.Windows.Forms.Label();
            this.grpShop = new System.Windows.Forms.GroupBox();
            this.lblShopInfo = new System.Windows.Forms.Label();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.lblDifficultyInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkShowOnStartup = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.grpMouse.SuspendLayout();
            this.grpKeyboard.SuspendLayout();
            this.grpItems.SuspendLayout();
            this.grpBoost.SuspendLayout();
            this.grpShop.SuspendLayout();
            this.grpDifficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.lblWelcome);
            this.mainPanel.Controls.Add(this.lblDescription);
            this.mainPanel.Controls.Add(this.grpMouse);
            this.mainPanel.Controls.Add(this.grpKeyboard);
            this.mainPanel.Controls.Add(this.grpItems);
            this.mainPanel.Controls.Add(this.grpBoost);
            this.mainPanel.Controls.Add(this.grpShop);
            this.mainPanel.Controls.Add(this.grpDifficulty);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(10, 10);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainPanel.Size = new System.Drawing.Size(530, 520);
            this.mainPanel.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(10, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(490, 35);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "🎮 Добро пожаловать в Catch them all!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(10, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(490, 40);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Собирайте монеты и кристаллы, зарабатывайте очки и покупайте новые скины для персонажа!";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpMouse
            // 
            this.grpMouse.Controls.Add(this.lblMouseInfo);
            this.grpMouse.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpMouse.Location = new System.Drawing.Point(13, 100);
            this.grpMouse.Name = "grpMouse";
            this.grpMouse.Size = new System.Drawing.Size(487, 70);
            this.grpMouse.TabIndex = 2;
            this.grpMouse.TabStop = false;
            this.grpMouse.Text = "🖱️ Управление мышью";
            // 
            // lblMouseInfo
            // 
            this.lblMouseInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMouseInfo.Location = new System.Drawing.Point(10, 25);
            this.lblMouseInfo.Name = "lblMouseInfo";
            this.lblMouseInfo.Size = new System.Drawing.Size(467, 35);
            this.lblMouseInfo.TabIndex = 0;
            this.lblMouseInfo.Text = "• Клик ПКМ по карте — движение к указанной точке\n• Зажать ПКМ на персонаже — перетаскивание";
            // 
            // grpKeyboard
            // 
            this.grpKeyboard.Controls.Add(this.lblKeyboardInfo);
            this.grpKeyboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpKeyboard.Location = new System.Drawing.Point(13, 180);
            this.grpKeyboard.Name = "grpKeyboard";
            this.grpKeyboard.Size = new System.Drawing.Size(487, 55);
            this.grpKeyboard.TabIndex = 3;
            this.grpKeyboard.TabStop = false;
            this.grpKeyboard.Text = "⌨️ Управление клавиатурой";
            // 
            // lblKeyboardInfo
            // 
            this.lblKeyboardInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKeyboardInfo.Location = new System.Drawing.Point(10, 25);
            this.lblKeyboardInfo.Name = "lblKeyboardInfo";
            this.lblKeyboardInfo.Size = new System.Drawing.Size(467, 25);
            this.lblKeyboardInfo.TabIndex = 0;
            this.lblKeyboardInfo.Text = "• WASD — движение персонажа";
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.lblItemsInfo);
            this.grpItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpItems.Location = new System.Drawing.Point(13, 315);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(487, 55);
            this.grpItems.TabIndex = 4;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "💎 Собираемые предметы";
            // 
            // lblItemsInfo
            // 
            this.lblItemsInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblItemsInfo.Location = new System.Drawing.Point(10, 25);
            this.lblItemsInfo.Name = "lblItemsInfo";
            this.lblItemsInfo.Size = new System.Drawing.Size(467, 25);
            this.lblItemsInfo.TabIndex = 0;
            this.lblItemsInfo.Text = "• 🟡 Монета = 1 очко | 🔵 Кристалл = 5 очков";
            // 
            // grpBoost
            // 
            this.grpBoost.Controls.Add(this.lblBoostInfo);
            this.grpBoost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoost.Location = new System.Drawing.Point(13, 245);
            this.grpBoost.Name = "grpBoost";
            this.grpBoost.Size = new System.Drawing.Size(487, 55);
            this.grpBoost.TabIndex = 6;
            this.grpBoost.TabStop = false;
            this.grpBoost.Text = "⚡ Ускорение";
            // 
            // lblBoostInfo
            // 
            this.lblBoostInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBoostInfo.Location = new System.Drawing.Point(10, 25);
            this.lblBoostInfo.Name = "lblBoostInfo";
            this.lblBoostInfo.Size = new System.Drawing.Size(467, 25);
            this.lblBoostInfo.TabIndex = 0;
            this.lblBoostInfo.Text = "• Зажмите SHIFT во время движения для ускорения";
            // 
            // grpShop
            // 
            this.grpShop.Controls.Add(this.lblShopInfo);
            this.grpShop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpShop.Location = new System.Drawing.Point(13, 385);
            this.grpShop.Name = "grpShop";
            this.grpShop.Size = new System.Drawing.Size(487, 55);
            this.grpShop.TabIndex = 5;
            this.grpShop.TabStop = false;
            this.grpShop.Text = "🛒 Магазин скинов";
            // 
            // lblShopInfo
            // 
            this.lblShopInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblShopInfo.Location = new System.Drawing.Point(10, 25);
            this.lblShopInfo.Name = "lblShopInfo";
            this.lblShopInfo.Size = new System.Drawing.Size(467, 25);
            this.lblShopInfo.TabIndex = 0;
            this.lblShopInfo.Text = "• Покупайте новые скины за заработанные монеты";
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.lblDifficultyInfo);
            this.grpDifficulty.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpDifficulty.Location = new System.Drawing.Point(13, 455);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Size = new System.Drawing.Size(487, 55);
            this.grpDifficulty.TabIndex = 7;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = "⚙️ Сложность";
            // 
            // lblDifficultyInfo
            // 
            this.lblDifficultyInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDifficultyInfo.Location = new System.Drawing.Point(10, 25);
            this.lblDifficultyInfo.Name = "lblDifficultyInfo";
            this.lblDifficultyInfo.Size = new System.Drawing.Size(467, 25);
            this.lblDifficultyInfo.TabIndex = 0;
            this.lblDifficultyInfo.Text = "• Мирный, Легкий, Средний, Сложный. Настройки — кнопка ⚙";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClose.Location = new System.Drawing.Point(340, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Начать игру";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkShowOnStartup
            // 
            this.chkShowOnStartup.AutoSize = true;
            this.chkShowOnStartup.Checked = true;
            this.chkShowOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnStartup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkShowOnStartup.Location = new System.Drawing.Point(23, 552);
            this.chkShowOnStartup.Name = "chkShowOnStartup";
            this.chkShowOnStartup.Size = new System.Drawing.Size(210, 23);
            this.chkShowOnStartup.TabIndex = 2;
            this.chkShowOnStartup.Text = "Показывать при запуске";
            this.chkShowOnStartup.UseVisualStyleBackColor = true;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 595);
            this.Controls.Add(this.chkShowOnStartup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catch them all — Справка";
            this.mainPanel.ResumeLayout(false);
            this.grpMouse.ResumeLayout(false);
            this.grpKeyboard.ResumeLayout(false);
            this.grpItems.ResumeLayout(false);
            this.grpBoost.ResumeLayout(false);
            this.grpShop.ResumeLayout(false);
            this.grpDifficulty.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public bool ShowOnStartup => chkShowOnStartup.Checked;
    }
}