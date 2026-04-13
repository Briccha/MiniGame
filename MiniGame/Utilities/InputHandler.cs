using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsGame.Utilities
{
    public enum InputState
    {
        Idle,
        Dragging,
        MovingToTarget
    }

    public class InputHandler
    {
        public InputState CurrentState { get; set; } = InputState.Idle;
        public Point DragOffset { get; set; }
        public bool IsWPressed { get; set; }
        public bool IsAPressed { get; set; }
        public bool IsSPressed { get; set; }
        public bool IsDPressed { get; set; }

        public PointF GetKeyboardMovementVector(float speed)
        {
            float dx = 0, dy = 0;

            if (IsDPressed) dx += speed;
            if (IsAPressed) dx -= speed;
            if (IsSPressed) dy += speed;
            if (IsWPressed) dy -= speed;

            return new PointF(dx, dy);
        }

        public bool IsShiftPressed { get; set; }

        public void HandleKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: IsWPressed = true; break;
                case Keys.A: IsAPressed = true; break;
                case Keys.S: IsSPressed = true; break;
                case Keys.D: IsDPressed = true; break;
                case Keys.ShiftKey: IsShiftPressed = true; break;
            }
        }

        public void HandleKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: IsWPressed = false; break;
                case Keys.A: IsAPressed = false; break;
                case Keys.S: IsSPressed = false; break;
                case Keys.D: IsDPressed = false; break;
                case Keys.ShiftKey: IsShiftPressed = false; break;
            }
        }

        public bool IsBoosting => IsShiftPressed;
    }
}