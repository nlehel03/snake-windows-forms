using System;
using System.Drawing;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public class GameScrollBar : Control
    {
        private bool _dragging;
        private int _dragOffset;
        private int _value;
        private int _maximum;
        public int LargeChange { get; set; } = 5;
        public int SmallChange { get; set; } = 1;

        public Color TrackColor { get; set; } = Color.FromArgb(32, 128, 32);
        public Color ThumbColor { get; set; } = Color.Lime;
        public Color BorderColor { get; set; } = Color.Lime;

        public int Value
        {
            get => _value;
            set
            {
                int v = Math.Max(0, Math.Min(value, Maximum));
                if (_value != v)
                {
                    _value = v;
                    Invalidate();
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = Math.Max(0, value);
                if (_value > _maximum) _value = _maximum;
                Invalidate();
            }
        }

        public event EventHandler? ValueChanged;

        public GameScrollBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            BackColor = Color.Black;
            Width = 14;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);

            using var track = new SolidBrush(TrackColor);
            var trackRect = ClientRectangle;
            trackRect.Inflate(-3, -3);
            g.FillRectangle(track, trackRect);

            var (thumbTop, thumbHeight) = GetThumbRect();
            using var thumb = new SolidBrush(ThumbColor);
            var thumbRect = new Rectangle(3, thumbTop, Width - 6, thumbHeight);
            g.FillRectangle(thumb, thumbRect);

            using var pen = new Pen(BorderColor, 1f);
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        private (int top, int height) GetThumbRect()
        {
            int total = Height - 6;
            if (total <= 0) return (3, 10);

            int page = Math.Max(1, LargeChange);
            int thumbHeight = Math.Max(14, total * page / (Maximum + page));
            int maxTop = Math.Max(0, total - thumbHeight);
            int top = 3 + (Maximum == 0 ? 0 : maxTop * Value / Maximum);
            return (top, thumbHeight);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            var (thumbTop, thumbHeight) = GetThumbRect();
            var thumbRect = new Rectangle(3, thumbTop, Width - 6, thumbHeight);

            if (thumbRect.Contains(e.Location))
            {
                _dragging = true;
                _dragOffset = e.Y - thumbTop;
                Capture = true;
            }
            else
            {
                if (e.Y < thumbTop) Value = Math.Max(0, Value - LargeChange);
                else if (e.Y > thumbTop + thumbHeight) Value = Math.Min(Maximum, Value + LargeChange);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_dragging)
            {
                int total = Height - 6;
                var (_, thumbHeight) = GetThumbRect();
                int maxTop = Math.Max(0, total - thumbHeight);
                int newTop = Math.Max(3, Math.Min(3 + maxTop, e.Y - _dragOffset));
                int pos = newTop - 3;
                Value = (maxTop == 0) ? 0 : (pos * Maximum) / maxTop;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_dragging)
            {
                _dragging = false;
                Capture = false;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int steps = e.Delta / SystemInformation.MouseWheelScrollDelta;
            if (steps != 0)
            {
                Value = Math.Max(0, Math.Min(Maximum, Value - steps * SmallChange));
            }
        }
    }
}

