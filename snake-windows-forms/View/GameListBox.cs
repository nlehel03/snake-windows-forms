using System;
using System.Drawing;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public class GameListBox : ListBox
    {
        public Color BoxBackground { get; set; } = Color.Black;
        public Color BoxForeColor { get; set; } = Color.Lime;
        public Color SelectionBackColor { get; set; } = Color.Green;
        public Color SelectionForeColor { get; set; } = Color.Black;

        private readonly GameScrollBar _scroll = new GameScrollBar();

        public GameListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            BorderStyle = BorderStyle.None;
            Font = new Font("Courier New", 12f, FontStyle.Bold);
            BackColor = BoxBackground;
            ForeColor = BoxForeColor;
            IntegralHeight = false;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            ItemHeight = (int)(Font.Height * 1.5f);

            _scroll.Dock = DockStyle.Right;
            _scroll.Visible = false;
            _scroll.ValueChanged += (s, e) =>
            {
                if (_scroll.Maximum >= 0 && TopIndex != _scroll.Value)
                {
                    TopIndex = _scroll.Value;
                    Invalidate();
                }
            };
            Controls.Add(_scroll);
            _scroll.BringToFront();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_VSCROLL = 0x00200000;
                var cp = base.CreateParams;
                cp.Style &= ~WS_VSCROLL;
                return cp;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateScrollBar();
        }

        protected override void WndProc(ref Message m)
        {
            const int LB_ADDSTRING = 0x0180;
            const int LB_INSERTSTRING = 0x0181;
            const int LB_DELETESTRING = 0x0182;
            const int LB_RESETCONTENT = 0x0184;

            base.WndProc(ref m);

            if (m.Msg == LB_ADDSTRING || m.Msg == LB_INSERTSTRING ||
                m.Msg == LB_DELETESTRING || m.Msg == LB_RESETCONTENT)
            {
                UpdateScrollBar();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count)
            {
                using var bg = new SolidBrush(BoxBackground);
                e.Graphics.FillRectangle(bg, e.Bounds);
                return;
            }

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bounds = e.Bounds;
            Color back = selected ? SelectionBackColor : BoxBackground;
            Color fore = selected ? SelectionForeColor : BoxForeColor;

            using (var b = new SolidBrush(back))
                e.Graphics.FillRectangle(b, bounds);

            var textRect = new Rectangle(bounds.X + 4, bounds.Y, 
                Math.Max(0, bounds.Width - 4 - (_scroll.Visible ? _scroll.Width : 0)), 
                bounds.Height);

            TextRenderer.DrawText(
                e.Graphics,
                Items[e.Index]?.ToString() ?? string.Empty,
                Font,
                textRect,
                fore,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

            e.DrawFocusRectangle();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int steps = e.Delta / SystemInformation.MouseWheelScrollDelta;
            if (steps != 0)
            {
                int small = Math.Max(1, _scroll.SmallChange);
                int visible = Math.Max(1, ClientSize.Height / Math.Max(1, ItemHeight));
                int maxTopIndex = Math.Max(0, Items.Count - visible);

                int newTop = Math.Max(0, Math.Min(maxTopIndex, TopIndex - steps * small));
                if (newTop != TopIndex)
                {
                    TopIndex = newTop;
                    SyncScrollFromList();
                    Invalidate();
                }
            }
            base.OnMouseWheel(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateScrollBar();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ItemHeight = (int)(Font.Height * 1.5f);
            UpdateScrollBar();
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            UpdateScrollBar();
        }

        public void RefreshScroll()
        {
            UpdateScrollBar();
        }

        private void UpdateScrollBar()
        {
            int visibleItems = Math.Max(1, ClientSize.Height / Math.Max(1, ItemHeight));
            int maxTopIndex = Math.Max(0, Items.Count - visibleItems);

            _scroll.LargeChange = Math.Max(1, visibleItems - 1);
            _scroll.Maximum = maxTopIndex;
            _scroll.Value = Math.Max(0, Math.Min(maxTopIndex, TopIndex));
            _scroll.Visible = maxTopIndex > 0;

            _scroll.BringToFront();
            Invalidate();
        }

        private void SyncScrollFromList()
        {
            int visibleItems = Math.Max(1, ClientSize.Height / Math.Max(1, ItemHeight));
            int maxTopIndex = Math.Max(0, Items.Count - visibleItems);

            _scroll.Maximum = maxTopIndex;
            _scroll.Value = Math.Max(0, Math.Min(maxTopIndex, TopIndex));
            _scroll.Visible = maxTopIndex > 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var pen = new Pen(Color.Lime, 2f);
            var r = ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            e.Graphics.DrawRectangle(pen, r);
        }
    }
}
