namespace WinFormsGame.Views
{
    partial class ShopForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstSkins;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblSkinInfo;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCurrentBalance;

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
            this.lstSkins = new System.Windows.Forms.ListBox();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblSkinInfo = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstSkins
            // 
            this.lstSkins.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstSkins.FormattingEnabled = true;
            this.lstSkins.ItemHeight = 20;
            this.lstSkins.Location = new System.Drawing.Point(9, 10);
            this.lstSkins.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstSkins.Name = "lstSkins";
            this.lstSkins.Size = new System.Drawing.Size(151, 244);
            this.lstSkins.TabIndex = 0;
            // 
            // previewPanel
            // 
            this.previewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(172, 10);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(150, 163);
            this.previewPanel.TabIndex = 1;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(225, 175);
            this.lblPreview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(82, 13);
            this.lblPreview.TabIndex = 2;
            this.lblPreview.Text = "Предпросмотр";
            // 
            // lblSkinInfo
            // 
            this.lblSkinInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSkinInfo.Location = new System.Drawing.Point(172, 203);
            this.lblSkinInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSkinInfo.Name = "lblSkinInfo";
            this.lblSkinInfo.Size = new System.Drawing.Size(150, 49);
            this.lblSkinInfo.TabIndex = 3;
            this.lblSkinInfo.Text = "Выберите скин";
            // 
            // btnBuy
            // 
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuy.Location = new System.Drawing.Point(166, 260);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(71, 28);
            this.btnBuy.TabIndex = 4;
            this.btnBuy.Text = "Купить";
            this.btnBuy.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSelect.Location = new System.Drawing.Point(241, 260);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 28);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.Location = new System.Drawing.Point(241, 301);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentBalance.Location = new System.Drawing.Point(9, 268);
            this.lblCurrentBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(150, 24);
            this.lblCurrentBalance.TabIndex = 7;
            this.lblCurrentBalance.Text = "Баланс: 0 монет";
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 333);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lblSkinInfo);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.lstSkins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Магазин скинов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}