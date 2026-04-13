using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsGame.Models;
using WinFormsGame.Utilities;
using WinFormsGame.Views;

namespace WinFormsGame.Presenters
{
    public class GamePresenter
    {
        private GameModel model;
        private GameCanvas view;
        private InputHandler inputHandler;

        public event EventHandler ScoreChanged;

        public InputHandler InputHandler => inputHandler;

        public GamePresenter(GameModel model, GameCanvas view)
        {
            this.model = model;
            this.view = view;
            this.inputHandler = new InputHandler();

            SubscribeToViewEvents();
            SubscribeToModelEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.MapClicked += View_MapClicked;
            view.PlayerDragStarted += View_PlayerDragStarted;
            view.PlayerDragged += View_PlayerDragged;
            view.PlayerDragEnded += View_PlayerDragEnded;
        }

        private void SubscribeToModelEvents()
        {
            model.ScoreChanged += (s, e) => ScoreChanged?.Invoke(this, e);
        }

        private void View_MapClicked(object sender, Point e)
        {
            if (inputHandler.CurrentState == InputState.Idle)
            {
                model.SetPlayerTarget(e);
                inputHandler.CurrentState = InputState.MovingToTarget;
            }
        }

        private void View_PlayerDragStarted(object sender, Point e)
        {
            inputHandler.CurrentState = InputState.Dragging;
        }

        private void View_PlayerDragged(object sender, Point e)
        {
            if (inputHandler.CurrentState == InputState.Dragging)
            {
                model.Player.Position = e;
                model.Player.TargetPosition = e;
            }
        }

        private void View_PlayerDragEnded(object sender, EventArgs e)
        {
            inputHandler.CurrentState = InputState.Idle;
        }

        public void HandleKeyDown(KeyEventArgs e)
        {
            inputHandler.HandleKeyDown(e);
        }

        public void HandleKeyUp(KeyEventArgs e)
        {
            inputHandler.HandleKeyUp(e);
        }

        public void Update()
        {
            if (inputHandler.CurrentState != InputState.Dragging)
            {
                var movementVector = inputHandler.GetKeyboardMovementVector(
                    inputHandler.IsBoosting ? model.Player.Speed * 2 : model.Player.Speed);
                if (movementVector.X != 0 || movementVector.Y != 0)
                {
                    model.MovePlayerByVector(movementVector);
                    inputHandler.CurrentState = InputState.MovingToTarget;
                }
            }

            model.Update(inputHandler.IsBoosting);

            if (!model.Player.IsMoving && inputHandler.CurrentState == InputState.MovingToTarget)
            {
                inputHandler.CurrentState = InputState.Idle;
            }
        }

        public void ApplySettings(GameSettings settings)
        {
            model.ApplySettings(settings);
        }
        public void UpdateMapBounds(Rectangle bounds)
        {
            model.MapBounds = bounds;

            // Корректируем позицию игрока если он вышел за границы
            float halfSize = PlayerEntity.PlayerSize / 2;
            var pos = model.Player.Position;
            pos.X = Math.Max(halfSize, Math.Min(bounds.Width - halfSize, pos.X));
            pos.Y = Math.Max(halfSize, Math.Min(bounds.Height - halfSize, pos.Y));
            model.Player.Position = pos;
            model.Player.TargetPosition = pos;
        }

        public int GetPlayerBalance()
        {
            return model.Player.Balance;
        }

        public string GetPlayerName()
        {
            return model.Player.Name;
        }

        public void SetPlayerName(string name)
        {
            model.Player.Name = name;
        }

        public PlayerEntity GetPlayer()
        {
            return model.Player;
        }
    }
}