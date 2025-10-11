using System;
using System.Drawing;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public class GameButton : Button
    {
        public Color BorderColor { get; set; } = Color.Green;
        public Color BackgroundColor { get; set; } = Color.Black;
        public Color TextColor { get; set; } = Color.Green;
        public Font TextFont { get; set; } = new Font("Courier New",14f, FontStyle.Bold);
        public int BorderSize { get; set; } = 1; 
        public GameButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            BackColor = BackgroundColor;
            ForeColor = TextColor;
            this.Font = TextFont;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            using (var b = new SolidBrush(BackgroundColor))
            {
                g.FillRectangle(b, ClientRectangle);
            }
            using (var pen = new Pen(BorderColor, BorderSize))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                g.DrawRectangle(pen, 0, 0, Width-1, Height-1);
            }
            int padding = 6 + BorderSize;
            var textRect = new Rectangle(padding, padding, Math.Max(0, Width - padding * 2), Math.Max(0, Height - padding * 2));

            TextRenderer.DrawText(g, Text, TextFont, textRect, TextColor, TextFormatFlags.HorizontalCenter |TextFormatFlags.VerticalCenter);


        }

    }
}
