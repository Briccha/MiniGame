using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinFormsGame.Models;
using WinFormsGame.Utilities;

namespace WinFormsGame.Views
{
    public partial class GameCanvas : UserControl
    {
        private const double ClickIndicatorDurationSeconds = 0.40;
        private GameModel gameModel;
        private InputHandler inputHandler;
        private bool isDragging = false;
        private PointF? clickIndicatorCenter;
        private DateTime clickIndicatorUntilUtc = DateTime.MinValue;
        private Color gridColor = Color.FromArgb(188, 202, 221);
        private Color borderColor = Color.FromArgb(120, 141, 166);
        private Color contrastHighlightColor = Color.FromArgb(28, 90, 210);

        public event EventHandler<Point> MapClicked;
        public event EventHandler<Point> PlayerDragStarted;
        public event EventHandler<Point> PlayerDragged;
        public event EventHandler PlayerDragEnded;

        public GameCanvas()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            MouseDown += GameCanvas_MouseDown;
            MouseMove += GameCanvas_MouseMove;
            MouseUp += GameCanvas_MouseUp;
            Paint += GameCanvas_Paint;
        }

        public void SetModel(GameModel model)
        {
            gameModel = model;
            gameModel.PlayerMoved += (s, e) => Invalidate();
            gameModel.ItemsChanged += (s, e) => Invalidate();
            gameModel.MonstersChanged += (s, e) => Invalidate();
            gameModel.PlayerStateChanged += (s, e) => Invalidate();
        }

        public void SetInputHandler(InputHandler handler)
        {
            inputHandler = handler;
        }

        private void GameCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameModel == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                StartClickIndicator(e.Location);
                MapClicked?.Invoke(this, e.Location);
                return;
            }

            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var playerBounds = new RectangleF(
                gameModel.Player.Position.X - PlayerEntity.PlayerSize / 2,
                gameModel.Player.Position.Y - PlayerEntity.PlayerSize / 2,
                PlayerEntity.PlayerSize,
                PlayerEntity.PlayerSize);

            if (playerBounds.Contains(e.Location))
            {
                isDragging = true;
                if (inputHandler != null)
                {
                    inputHandler.CurrentState = InputState.Dragging;
                }
                PlayerDragStarted?.Invoke(this, e.Location);
                return;
            }
        }

        private void GameCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && gameModel != null)
            {
                PlayerDragged?.Invoke(this, e.Location);
                Invalidate();
            }
        }

        private void GameCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Right)
            {
                isDragging = false;
                if (inputHandler != null)
                {
                    inputHandler.CurrentState = InputState.Idle;
                }
                PlayerDragEnded?.Invoke(this, EventArgs.Empty);
            }
        }

        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (gameModel == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DrawMapGrid(g);
            DrawCollectibles(g);
            DrawMonsters(g);
            DrawPlayer(g);
            DrawPlayerName(g);
            DrawClickIndicator(g);
        }

        public void ApplyVisualTheme(ThemeManager.ThemePalette palette)
        {
            gridColor = palette.CanvasGridColor;
            borderColor = ColorHelper.GetHitFlashColor(palette.AccentColor, palette.BackColor);
            contrastHighlightColor = ColorHelper.GetPreferredContrastColor(palette.ContrastColor, palette.SurfaceColor);
            BackColor = palette.SurfaceColor;
            Invalidate();
        }

        private void DrawMapGrid(Graphics g)
        {
            using (Pen pen = new Pen(gridColor, 1))
            {
                pen.DashStyle = DashStyle.Dot;
                for (int x = 0; x < Width; x += 50) g.DrawLine(pen, x, 0, x, Height);
                for (int y = 0; y < Height; y += 50) g.DrawLine(pen, 0, y, Width, y);
            }

            using (Pen pen = new Pen(borderColor, 2))
            {
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void DrawCollectibles(Graphics g)
        {
            foreach (var item in gameModel.Items)
            {
                using (Brush brush = new SolidBrush(item.Color))
                {
                    g.FillEllipse(brush, item.Bounds);
                }

                if (item is Crystal)
                {
                    using (Font font = new Font("Arial", 8, FontStyle.Bold))
                    using (Brush brush = new SolidBrush(Color.White))
                    {
                        var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        g.DrawString("5", font, brush, item.Position, format);
                    }
                }
            }
        }

        private void DrawMonsters(Graphics g)
        {
            foreach (var monster in gameModel.Monsters)
            {
                using (Brush shadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                {
                    g.FillEllipse(shadow, monster.Bounds.X + 2, monster.Bounds.Y + 2, monster.Bounds.Width, monster.Bounds.Height);
                }

                var bodyColor = monster.IsHitFlashActive
                    ? ColorHelper.Blend(Color.IndianRed, monster.HitFlashColor, 0.55)
                    : Color.IndianRed;
                using (Brush body = new SolidBrush(bodyColor))
                {
                    g.FillEllipse(body, monster.Bounds);
                }

                DrawHealthBar(g, monster.Position.X, monster.Position.Y - MonsterEntity.MonsterSize / 2f - 10, 36, 5, monster.Health, monster.MaxHealth);
            }
        }

        private void DrawPlayer(Graphics g)
        {
            var skins = SkinData.GetAllSkins();
            var currentSkin = skins[gameModel.Player.CurrentSkinId];

            float size = PlayerEntity.PlayerSize;
            float x = gameModel.Player.Position.X - size / 2;
            float y = gameModel.Player.Position.Y - size / 2;

            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 3, y + 3, size, size);
            }

            var playerPrimary = gameModel.Player.IsHitFlashActive
                ? ColorHelper.Blend(currentSkin.PrimaryColor, gameModel.Player.HitFlashColor, 0.5)
                : currentSkin.PrimaryColor;
            var playerSecondary = gameModel.Player.IsHitFlashActive
                ? ColorHelper.GetHitFlashColor(currentSkin.SecondaryColor, playerPrimary)
                : currentSkin.SecondaryColor;

            using (Brush playerBrush = new SolidBrush(playerPrimary))
            {
                g.FillEllipse(playerBrush, x, y, size, size);
            }

            using (Brush detailBrush = new SolidBrush(playerSecondary))
            {
                g.FillEllipse(detailBrush, x + size / 4, y + size / 4, size / 2, size / 2);
            }

            DrawPlayerEyes(g, x, y, size);
            DrawHealthBar(g, gameModel.Player.Position.X, y - 8, 46, 6, gameModel.Player.Health, gameModel.Player.MaxHealth);

            if (gameModel.Player.IsMoving && inputHandler.CurrentState != InputState.Dragging)
            {
                using (Pen targetPen = new Pen(Color.FromArgb(180, contrastHighlightColor), 2.2f))
                {
                    targetPen.DashStyle = DashStyle.Dash;
                    g.DrawEllipse(targetPen,
                    gameModel.Player.TargetPosition.X - size / 2,
                    gameModel.Player.TargetPosition.Y - size / 2,
                    size, size);
                }
            }
        }

        private void DrawClickIndicator(Graphics g)
        {
            if (!clickIndicatorCenter.HasValue || DateTime.UtcNow > clickIndicatorUntilUtc)
            {
                clickIndicatorCenter = null;
                return;
            }

            var totalDuration = TimeSpan.FromSeconds(ClickIndicatorDurationSeconds).TotalMilliseconds;
            var progress = 1.0 - (clickIndicatorUntilUtc - DateTime.UtcNow).TotalMilliseconds / totalDuration;
            progress = Math.Max(0.0, Math.Min(1.0, progress));
            var radius = 18f + (float)(progress * 24f);
            var easedFade = 1.0 - Math.Pow(progress, 1.6);
            var alpha = (int)(110 * (1.0 - easedFade));
            var center = clickIndicatorCenter.Value;

            using (var ringPen = new Pen(Color.FromArgb(alpha, contrastHighlightColor), 2.3f))
            {
                g.DrawEllipse(ringPen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
        }

        private void StartClickIndicator(Point location)
        {
            clickIndicatorCenter = location;
            clickIndicatorUntilUtc = DateTime.UtcNow.AddSeconds(ClickIndicatorDurationSeconds);
            Invalidate();
        }

        private void DrawHealthBar(Graphics g, float centerX, float y, float width, float height, int health, int maxHealth)
        {
            float x = centerX - width / 2f;
            var ratio = maxHealth <= 0 ? 0f : Math.Max(0f, Math.Min(1f, (float)health / maxHealth));
            using (Brush bg = new SolidBrush(Color.FromArgb(180, 20, 20, 20)))
            {
                g.FillRectangle(bg, x, y, width, height);
            }
            using (Brush hp = new SolidBrush(Color.LimeGreen))
            {
                g.FillRectangle(hp, x, y, width * ratio, height);
            }
            using (Pen border = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(border, x, y, width, height);
            }
        }

        private void DrawPlayerEyes(Graphics g, float x, float y, float size)
        {
            float eyeSize = size / 6;
            float eyeY = y + size / 3;

            using (Brush eyeBrush = new SolidBrush(Color.White))
            {
                g.FillEllipse(eyeBrush, x + size / 4, eyeY, eyeSize, eyeSize);
                g.FillEllipse(eyeBrush, x + size * 3 / 4 - eyeSize, eyeY, eyeSize, eyeSize);
            }

            using (Brush pupilBrush = new SolidBrush(Color.Black))
            {
                float pupilOffset = eyeSize / 3;

                if (gameModel.Player.IsMoving)
                {
                    float dx = gameModel.Player.TargetPosition.X - gameModel.Player.Position.X;
                    float dy = gameModel.Player.TargetPosition.Y - gameModel.Player.Position.Y;
                    pupilOffset = Math.Abs(dx) > Math.Abs(dy)
                        ? (dx > 0 ? eyeSize / 3 : -eyeSize / 3)
                        : (dy > 0 ? eyeSize / 3 : -eyeSize / 3);
                }

                g.FillEllipse(pupilBrush, x + size / 4 + pupilOffset, eyeY, eyeSize / 2, eyeSize / 2);
                g.FillEllipse(pupilBrush, x + size * 3 / 4 - eyeSize + pupilOffset, eyeY, eyeSize / 2, eyeSize / 2);
            }
        }

        private void DrawPlayerName(Graphics g)
        {
            string text = gameModel.Player.Name;
            float size = PlayerEntity.PlayerSize;
            float x = gameModel.Player.Position.X;
            float y = gameModel.Player.Position.Y - size / 2 - 24;

            using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
            {
                SizeF textSize = g.MeasureString(text, font);

                using (Brush bgBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0)))
            {
                g.FillRectangle(bgBrush, x - textSize.Width / 2 - 5, y - textSize.Height / 2 - 2, textSize.Width + 10, textSize.Height + 4);
            }

            using (Brush textBrush = new SolidBrush(Color.White))
            {
                var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(text, font, textBrush, x, y, format);
                }
            }
        }
    }
}
