using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public partial class ChooseView : Form
    {
        public int c;
        public int n;
        public ChooseView()
        {
            InitializeComponent();
            mediumMapButton.Click += mediumMapButton_Click;
            smallMapButton.Click += smallMapButton_Click;
            largeMapButton.Click += largeMapButton_Click;
        }

   
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void smallMapButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            c = 40;
            n = 13;
            using (var game = new GameView(c, n))
            {
                game.StartPosition = FormStartPosition.Manual;
                game.Location = this.Location;
                game.Size = this.Size;
                game.ShowDialog(this);
            }
            
        }

        private void mediumMapButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            c = 20;
            n = 25;
            using (var game = new GameView(c, n))
            {
                game.StartPosition = FormStartPosition.Manual;
                game.Location = this.Location;
                game.Size = this.Size;
                game.ShowDialog(this);
            }
            
        }

        private void largeMapButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            c = 10;
            n = 50;
            using (var game = new GameView(c, n))
            {
                game.StartPosition = FormStartPosition.Manual;
                game.Location = this.Location;
                game.Size = this.Size;
                game.ShowDialog(this);
            }
            ;
        }
    }
}
