using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public class GameTextBox : TextBox
    {
        private const int WM_PAINT = 0x000F;
        private const int WM_NCPAINT = 0x0085;

        [Browsable(true)]
        [Category("Appearance")]
        public Color BorderColor { get; set; } = Color.Green;

        [Browsable(true)]
        [Category("Appearance")]
        public Color BackgroundColor { get; set; } = Color.Black;

        [Browsable(true)]
        [Category("Appearance")]
        public Color TextColor { get; set; } = Color.Green;

        [Browsable(true)]
        [Category("Appearance")]
        public Font TextFont { get; set; } = new Font("Courier New", 14f, FontStyle.Bold);

        [Browsable(true)]
        [Category("Appearance")]
        public int BorderSize { get; set; } = 1;

        [Browsable(true)]
        [Category("Layout")]
        public int InnerPadding { get; set; } = 6;

        public GameTextBox()
        {
            
            Multiline = false;

            BorderStyle = BorderStyle.None; 
            BackColor = BackgroundColor;
            ForeColor = TextColor;
            Font = TextFont;
            Padding = new Padding(InnerPadding);
            
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            TextFont = this.Font;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BackColor = BackgroundColor;
            ForeColor = TextColor;
            Font = TextFont;
            try { Padding = new Padding(InnerPadding); } catch { }
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT || m.Msg == WM_NCPAINT)
            {
                using (var g = Graphics.FromHwnd(this.Handle))
                using (var pen = new Pen(BorderColor, Math.Max(1, BorderSize)))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    var rect = new Rectangle(0, 0, Width - 1, Height - 1);
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    g.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
