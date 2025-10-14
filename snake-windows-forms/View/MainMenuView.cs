using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public partial class MainMenuView : Form
    {
        public MainMenuView()
        {
            InitializeComponent();
            startGameButton.Click += StartGameButton_Click;
        }

        private void StartGameButton_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var choose = new ChooseView())
            {
                choose.StartPosition = FormStartPosition.Manual;
                choose.Location = this.Location;
                choose.Size = this.Size;
                choose.ShowDialog(this);
            }

        }

        private void leaderBoardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var lb = new LeaderboardView())
            {
                lb.StartPosition = FormStartPosition.Manual;
                lb.Location = this.Location;
                lb.Size = this.Size;
                lb.ShowDialog(this);
            }
        }
    }
}
