using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsGame.Models;

namespace WinFormsGame.Views
{
    public partial class ShopForm : Form
    {
        private PlayerEntity player;
        private SkinData selectedSkin;

        public ShopForm(PlayerEntity player)
        {
            InitializeComponent();
            this.player = player;
            LoadSkins();
            UpdateBalance();
        }

        private void LoadSkins()
        {
            var skins = SkinData.GetAllSkins();
            foreach (var skin in skins)
            {
                string status = player.UnlockedSkins.Contains(skin.Id) ? "✅" : "🔒";
                string price = skin.Cost > 0 ? $" - {skin.Cost} монет" : " - Бесплатно";
                lstSkins.Items.Add($"{status} {skin.Name}{price}");
            }
            lstSkins.Tag = skins;
        }

        private void LstSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSkins.SelectedIndex >= 0)
            {
                var skins = (System.Collections.Generic.List<SkinData>)lstSkins.Tag;
                selectedSkin = skins[lstSkins.SelectedIndex];

                bool isUnlocked = player.UnlockedSkins.Contains(selectedSkin.Id);
                bool isCurrent = player.CurrentSkinId == selectedSkin.Id;

                string status = isUnlocked ? (isCurrent ? "✅ Выбран" : "✅ Доступен") : $"🔒 {selectedSkin.Cost} монет";
                lblSkinInfo.Text = $"{selectedSkin.Name}\n{status}";

                btnBuy.Enabled = !isUnlocked && player.Balance >= selectedSkin.Cost;
                btnSelect.Enabled = isUnlocked && !isCurrent;

                previewPanel.Invalidate();
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            if (selectedSkin != null && player.Balance >= selectedSkin.Cost)
            {
                player.Balance -= selectedSkin.Cost;
                player.UnlockedSkins.Add(selectedSkin.Id);
                player.CurrentSkinId = selectedSkin.Id;

                UpdateBalance();
                RefreshSkinsList();
                LstSkins_SelectedIndexChanged(sender, e);

                DialogResult = DialogResult.OK;
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (selectedSkin != null && player.UnlockedSkins.Contains(selectedSkin.Id))
            {
                player.CurrentSkinId = selectedSkin.Id;
                RefreshSkinsList();
                LstSkins_SelectedIndexChanged(sender, e);

                DialogResult = DialogResult.OK;
            }
        }

        private void RefreshSkinsList()
        {
            int selectedIndex = lstSkins.SelectedIndex;
            lstSkins.Items.Clear();
            LoadSkins();
            lstSkins.SelectedIndex = selectedIndex;
        }

        private void UpdateBalance()
        {
            lblCurrentBalance.Text = $"Баланс: {player.Balance} монет";
        }

        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            if (selectedSkin == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float size = 100;
            float x = (previewPanel.Width - size) / 2;
            float y = (previewPanel.Height - size) / 2;

            // Рисуем скин
            using (Brush brush = new SolidBrush(selectedSkin.PrimaryColor))
            {
                g.FillEllipse(brush, x, y, size, size);
            }

            using (Brush brush = new SolidBrush(selectedSkin.SecondaryColor))
            {
                g.FillEllipse(brush, x + size / 4, y + size / 4, size / 2, size / 2);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
