namespace WinFormsGame.Views
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPlayerSection;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPlayerHp;
        private System.Windows.Forms.Label lblPlayerDamage;
        private System.Windows.Forms.Label lblPlayerSpeed;
        private System.Windows.Forms.Label lblDifficultySection;
        private System.Windows.Forms.Label lblMonsterCount;
        private System.Windows.Forms.Label lblMonsterHp;
        private System.Windows.Forms.Label lblMonsterDamage;
        private System.Windows.Forms.Label lblMonsterSpeed;
        private System.Windows.Forms.Label lblMonsterVision;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numPlayerHp;
        private System.Windows.Forms.NumericUpDown numPlayerDamage;
        private System.Windows.Forms.NumericUpDown numPlayerSpeed;
        private System.Windows.Forms.NumericUpDown numMonsterCount;
        private System.Windows.Forms.NumericUpDown numMonsterHp;
        private System.Windows.Forms.NumericUpDown numMonsterDamage;
        private System.Windows.Forms.NumericUpDown numMonsterSpeed;
        private System.Windows.Forms.NumericUpDown numMonsterVision;

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
            this.lblPlayerSection = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPlayerHp = new System.Windows.Forms.Label();
            this.lblPlayerDamage = new System.Windows.Forms.Label();
            this.lblPlayerSpeed = new System.Windows.Forms.Label();
            this.lblDifficultySection = new System.Windows.Forms.Label();
            this.lblMonsterCount = new System.Windows.Forms.Label();
            this.lblMonsterHp = new System.Windows.Forms.Label();
            this.lblMonsterDamage = new System.Windows.Forms.Label();
            this.lblMonsterSpeed = new System.Windows.Forms.Label();
            this.lblMonsterVision = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numPlayerHp = new System.Windows.Forms.NumericUpDown();
            this.numPlayerDamage = new System.Windows.Forms.NumericUpDown();
            this.numPlayerSpeed = new System.Windows.Forms.NumericUpDown();
            this.numMonsterCount = new System.Windows.Forms.NumericUpDown();
            this.numMonsterHp = new System.Windows.Forms.NumericUpDown();
            this.numMonsterDamage = new System.Windows.Forms.NumericUpDown();
            this.numMonsterSpeed = new System.Windows.Forms.NumericUpDown();
            this.numMonsterVision = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterVision)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerSection
            // 
            this.lblPlayerSection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPlayerSection.Location = new System.Drawing.Point(20, 15);
            this.lblPlayerSection.Name = "lblPlayerSection";
            this.lblPlayerSection.Size = new System.Drawing.Size(300, 23);
            this.lblPlayerSection.TabIndex = 0;
            this.lblPlayerSection.Text = "Игрок";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.Location = new System.Drawing.Point(20, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(135, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Никнейм";
            // 
            // lblPlayerHp
            // 
            this.lblPlayerHp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayerHp.Location = new System.Drawing.Point(20, 85);
            this.lblPlayerHp.Name = "lblPlayerHp";
            this.lblPlayerHp.Size = new System.Drawing.Size(135, 23);
            this.lblPlayerHp.TabIndex = 2;
            this.lblPlayerHp.Text = "ХП";
            // 
            // lblPlayerDamage
            // 
            this.lblPlayerDamage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayerDamage.Location = new System.Drawing.Point(20, 119);
            this.lblPlayerDamage.Name = "lblPlayerDamage";
            this.lblPlayerDamage.Size = new System.Drawing.Size(135, 23);
            this.lblPlayerDamage.TabIndex = 3;
            this.lblPlayerDamage.Text = "Урон";
            // 
            // lblPlayerSpeed
            // 
            this.lblPlayerSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayerSpeed.Location = new System.Drawing.Point(20, 153);
            this.lblPlayerSpeed.Name = "lblPlayerSpeed";
            this.lblPlayerSpeed.Size = new System.Drawing.Size(135, 23);
            this.lblPlayerSpeed.TabIndex = 4;
            this.lblPlayerSpeed.Text = "Скорость";
            // 
            // lblDifficultySection
            // 
            this.lblDifficultySection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDifficultySection.Location = new System.Drawing.Point(20, 195);
            this.lblDifficultySection.Name = "lblDifficultySection";
            this.lblDifficultySection.Size = new System.Drawing.Size(300, 23);
            this.lblDifficultySection.TabIndex = 5;
            this.lblDifficultySection.Text = "Текущая сложность";
            // 
            // lblMonsterCount
            // 
            this.lblMonsterCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonsterCount.Location = new System.Drawing.Point(20, 231);
            this.lblMonsterCount.Name = "lblMonsterCount";
            this.lblMonsterCount.Size = new System.Drawing.Size(135, 23);
            this.lblMonsterCount.TabIndex = 6;
            this.lblMonsterCount.Text = "Монстры";
            // 
            // lblMonsterHp
            // 
            this.lblMonsterHp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonsterHp.Location = new System.Drawing.Point(20, 265);
            this.lblMonsterHp.Name = "lblMonsterHp";
            this.lblMonsterHp.Size = new System.Drawing.Size(135, 23);
            this.lblMonsterHp.TabIndex = 7;
            this.lblMonsterHp.Text = "ХП монстра";
            // 
            // lblMonsterDamage
            // 
            this.lblMonsterDamage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonsterDamage.Location = new System.Drawing.Point(20, 299);
            this.lblMonsterDamage.Name = "lblMonsterDamage";
            this.lblMonsterDamage.Size = new System.Drawing.Size(135, 23);
            this.lblMonsterDamage.TabIndex = 8;
            this.lblMonsterDamage.Text = "Урон монстра";
            // 
            // lblMonsterSpeed
            // 
            this.lblMonsterSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonsterSpeed.Location = new System.Drawing.Point(20, 333);
            this.lblMonsterSpeed.Name = "lblMonsterSpeed";
            this.lblMonsterSpeed.Size = new System.Drawing.Size(135, 23);
            this.lblMonsterSpeed.TabIndex = 9;
            this.lblMonsterSpeed.Text = "Скорость монстра";
            // 
            // lblMonsterVision
            // 
            this.lblMonsterVision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonsterVision.Location = new System.Drawing.Point(20, 367);
            this.lblMonsterVision.Name = "lblMonsterVision";
            this.lblMonsterVision.Size = new System.Drawing.Size(135, 23);
            this.lblMonsterVision.TabIndex = 10;
            this.lblMonsterVision.Text = "Радиус зрения";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(125, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(170, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 22);
            this.txtName.TabIndex = 12;
            // 
            // numPlayerHp
            // 
            this.numPlayerHp.Location = new System.Drawing.Point(170, 85);
            this.numPlayerHp.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numPlayerHp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayerHp.Name = "numPlayerHp";
            this.numPlayerHp.Size = new System.Drawing.Size(160, 22);
            this.numPlayerHp.TabIndex = 13;
            this.numPlayerHp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numPlayerDamage
            // 
            this.numPlayerDamage.Location = new System.Drawing.Point(170, 119);
            this.numPlayerDamage.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numPlayerDamage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayerDamage.Name = "numPlayerDamage";
            this.numPlayerDamage.Size = new System.Drawing.Size(160, 22);
            this.numPlayerDamage.TabIndex = 14;
            this.numPlayerDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numPlayerSpeed
            // 
            this.numPlayerSpeed.DecimalPlaces = 1;
            this.numPlayerSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPlayerSpeed.Location = new System.Drawing.Point(170, 153);
            this.numPlayerSpeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPlayerSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayerSpeed.Name = "numPlayerSpeed";
            this.numPlayerSpeed.Size = new System.Drawing.Size(160, 22);
            this.numPlayerSpeed.TabIndex = 15;
            this.numPlayerSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMonsterCount
            // 
            this.numMonsterCount.Location = new System.Drawing.Point(170, 231);
            this.numMonsterCount.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMonsterCount.Name = "numMonsterCount";
            this.numMonsterCount.Size = new System.Drawing.Size(160, 22);
            this.numMonsterCount.TabIndex = 16;
            // 
            // numMonsterHp
            // 
            this.numMonsterHp.Location = new System.Drawing.Point(170, 265);
            this.numMonsterHp.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMonsterHp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonsterHp.Name = "numMonsterHp";
            this.numMonsterHp.Size = new System.Drawing.Size(160, 22);
            this.numMonsterHp.TabIndex = 17;
            this.numMonsterHp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMonsterDamage
            // 
            this.numMonsterDamage.Location = new System.Drawing.Point(170, 299);
            this.numMonsterDamage.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numMonsterDamage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonsterDamage.Name = "numMonsterDamage";
            this.numMonsterDamage.Size = new System.Drawing.Size(160, 22);
            this.numMonsterDamage.TabIndex = 18;
            this.numMonsterDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMonsterSpeed
            // 
            this.numMonsterSpeed.DecimalPlaces = 1;
            this.numMonsterSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMonsterSpeed.Location = new System.Drawing.Point(170, 333);
            this.numMonsterSpeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMonsterSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numMonsterSpeed.Name = "numMonsterSpeed";
            this.numMonsterSpeed.Size = new System.Drawing.Size(160, 22);
            this.numMonsterSpeed.TabIndex = 19;
            this.numMonsterSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // numMonsterVision
            // 
            this.numMonsterVision.Location = new System.Drawing.Point(170, 367);
            this.numMonsterVision.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numMonsterVision.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMonsterVision.Name = "numMonsterVision";
            this.numMonsterVision.Size = new System.Drawing.Size(160, 22);
            this.numMonsterVision.TabIndex = 20;
            this.numMonsterVision.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 445);
            this.Controls.Add(this.numMonsterVision);
            this.Controls.Add(this.numMonsterSpeed);
            this.Controls.Add(this.numMonsterDamage);
            this.Controls.Add(this.numMonsterHp);
            this.Controls.Add(this.numMonsterCount);
            this.Controls.Add(this.numPlayerSpeed);
            this.Controls.Add(this.numPlayerDamage);
            this.Controls.Add(this.numPlayerHp);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMonsterVision);
            this.Controls.Add(this.lblMonsterSpeed);
            this.Controls.Add(this.lblMonsterDamage);
            this.Controls.Add(this.lblMonsterHp);
            this.Controls.Add(this.lblMonsterCount);
            this.Controls.Add(this.lblDifficultySection);
            this.Controls.Add(this.lblPlayerSpeed);
            this.Controls.Add(this.lblPlayerDamage);
            this.Controls.Add(this.lblPlayerHp);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPlayerSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки игры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonsterVision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
