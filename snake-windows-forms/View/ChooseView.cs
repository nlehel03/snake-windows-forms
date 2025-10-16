using snake_windows_forms.Models;
using snake_windows_forms.Persistence;
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
        public MapSize mapSize;
        public FileManagement fm;
        public ChooseView()
        {
            InitializeComponent();
            mediumMapButton.Click += mediumMapButton_Click;
            smallMapButton.Click += smallMapButton_Click;
            largeMapButton.Click += largeMapButton_Click;
            fm = new FileManagement();
        }

        private void smallMapButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mapSize = fm.loadMapSize(0);
            
            using (var game = new GameView(mapSize.cellSize,mapSize.n))
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
            mapSize = fm.loadMapSize(1);
            using (var game = new GameView(mapSize.cellSize, mapSize.n))
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
            mapSize = fm.loadMapSize(2);
            using (var game = new GameView(mapSize.cellSize, mapSize.n))
            {
                game.StartPosition = FormStartPosition.Manual;
                game.Location = this.Location;
                game.Size = this.Size;
                game.ShowDialog(this);
            }
            
        }
    }
}
