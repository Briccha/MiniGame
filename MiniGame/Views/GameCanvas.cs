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
        private GameModel gameModel;
        private InputHandler inputHandler;
        private bool isDragging = false;
        private Point dragStart;

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
            this.MouseDown += GameCanvas_MouseDown;
            this.MouseMove += GameCanvas_MouseMove;
            this.MouseUp += GameCanvas_MouseUp;
            this.Paint += GameCanvas_Paint;
        }

        public void SetModel(GameModel model)
        {
            gameModel = model;
            gameModel.PlayerMoved += (s, e) => Invalidate();
            gameModel.ItemsChanged += (s, e) => Invalidate();
        }

        public void SetInputHandler(InputHandler handler)
        {
            inputHandler = handler;
        }

        private void GameCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameModel == null) return;

            // Проверяем, кликнули ли по персонажу
            var playerBounds = new RectangleF(
                gameModel.Player.Position.X - PlayerEntity.PlayerSize / 2,
                gameModel.Player.Position.Y - PlayerEntity.PlayerSize / 2,
                PlayerEntity.PlayerSize,
                PlayerEntity.PlayerSize
            );

            if (playerBounds.Contains(e.Location))
            {
                isDragging = true;
                dragStart = e.Location;
                inputHandler.CurrentState = InputState.Dragging;
                PlayerDragStarted?.Invoke(this, e.Location);
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
            if (isDragging)
            {
                isDragging = false;
                inputHandler.CurrentState = InputState.Idle;
                PlayerDragEnded?.Invoke(this, EventArgs.Empty);
            }
            else if (e.Button == MouseButtons.Left)
            {
                MapClicked?.Invoke(this, e.Location);
            }
        }

        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (gameModel == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Рисуем сетку карты
            DrawMapGrid(g);

            // Рисуем предметы
            DrawCollectibles(g);

            // Рисуем персонажа
            DrawPlayer(g);

            // Рисуем имя над головой
            DrawPlayerName(g);
        }

        private void DrawMapGrid(Graphics g)
        {
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                pen.DashStyle = DashStyle.Dot;

                for (int x = 0; x < Width; x += 50)
                    g.DrawLine(pen, x, 0, x, Height);
                for (int y = 0; y < Height; y += 50)
                    g.DrawLine(pen, 0, y, Width, y);
            }

            using (Pen pen = new Pen(Color.Gray, 2))
            {
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void DrawCollectibles(Graphics g)
        {
            var skins = SkinData.GetAllSkins();
            var currentSkin = skins[gameModel.Player.CurrentSkinId];

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
                        var format = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        g.DrawString("5", font, brush, item.Position, format);
                    }
                }
            }
        }

        private void DrawPlayer(Graphics g)
        {
            var skins = SkinData.GetAllSkins();
            var currentSkin = skins[gameModel.Player.CurrentSkinId];

            float size = PlayerEntity.PlayerSize;
            float x = gameModel.Player.Position.X - size / 2;
            float y = gameModel.Player.Position.Y - size / 2;

            // Тень
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, x + 3, y + 3, size, size);
            }

            // Основной персонаж
            using (Brush playerBrush = new SolidBrush(currentSkin.PrimaryColor))
            {
                g.FillEllipse(playerBrush, x, y, size, size);
            }

            // Детали персонажа
            using (Brush detailBrush = new SolidBrush(currentSkin.SecondaryColor))
            {
                g.FillEllipse(detailBrush, x + size / 4, y + size / 4, size / 2, size / 2);
            }

            // Глаза (направление движения)
            DrawPlayerEyes(g, x, y, size);

            // Индикатор цели при движении по клику
            if (gameModel.Player.IsMoving && inputHandler.CurrentState != InputState.Dragging)
            {
                using (Pen targetPen = new Pen(Color.FromArgb(100, 255, 255, 0), 2))
                {
                    targetPen.DashStyle = DashStyle.Dash;
                    g.DrawEllipse(targetPen,
                        gameModel.Player.TargetPosition.X - size / 2,
                        gameModel.Player.TargetPosition.Y - size / 2,
                        size, size);
                }
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

            // Зрачки смотрят в направлении цели
            using (Brush pupilBrush = new SolidBrush(Color.Black))
            {
                float pupilOffset = eyeSize / 3;

                if (gameModel.Player.IsMoving)
                {
                    float dx = gameModel.Player.TargetPosition.X - gameModel.Player.Position.X;
                    float dy = gameModel.Player.TargetPosition.Y - gameModel.Player.Position.Y;

                    if (Math.Abs(dx) > Math.Abs(dy))
                        pupilOffset = dx > 0 ? eyeSize / 3 : -eyeSize / 3;
                    else
                        pupilOffset = dy > 0 ? eyeSize / 3 : -eyeSize / 3;
                }

                g.FillEllipse(pupilBrush,
                    x + size / 4 + pupilOffset, eyeY,
                    eyeSize / 2, eyeSize / 2);
                g.FillEllipse(pupilBrush,
                    x + size * 3 / 4 - eyeSize + pupilOffset, eyeY,
                    eyeSize / 2, eyeSize / 2);
            }
        }

        private void DrawPlayerName(Graphics g)
        {
            string text = gameModel.Player.Name;
            float size = PlayerEntity.PlayerSize;
            float x = gameModel.Player.Position.X;
            float y = gameModel.Player.Position.Y - size / 2 - 20;

            using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                SizeF textSize = g.MeasureString(text, font);

                // Фон для текста
                using (Brush bgBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0)))
                {
                    g.FillRectangle(bgBrush,
                        x - textSize.Width / 2 - 5,
                        y - textSize.Height / 2 - 2,
                        textSize.Width + 10,
                        textSize.Height + 4);
                }

                // Текст
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    var format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(text, font, textBrush, x, y, format);
                }
            }
        }
    }
}