using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public class GameListBox : ListBox
    {
        public Color BoxBackground { get; set; } = Color.Black;
        public Color BoxForeColor { get; set; } = Color.Lime;
        public Color SelectionBackColor { get; set; } = Color.Green;
        public Color SelectionForeColor { get; set; } = Color.Black;

        public GameListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            BorderStyle = BorderStyle.None;
            Font = new Font("Courier New", 12f, FontStyle.Bold);
            BackColor = BoxBackground;
            ForeColor = BoxForeColor;

            // Stabil rajzolás (UserPaint nélkül, hogy az owner-draw működjön)
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            ItemHeight = (int)(Font.Height * 1.5f);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bounds = e.Bounds;
            Color back = selected ? SelectionBackColor : BoxBackground;
            Color fore = selected ? SelectionForeColor : BoxForeColor;

            using (var b = new SolidBrush(back))
                e.Graphics.FillRectangle(b, bounds);

            TextRenderer.DrawText(
                e.Graphics,
                Items[e.Index]?.ToString() ?? string.Empty,
                Font,
                bounds,
                fore,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

            e.DrawFocusRectangle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Zöld keret az egész kontroll köré
            using var pen = new Pen(Color.Lime, 2f);
            var r = ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            e.Graphics.DrawRectangle(pen, r);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BackColor = BoxBackground;
            ForeColor = BoxForeColor;
        }
    }
}
