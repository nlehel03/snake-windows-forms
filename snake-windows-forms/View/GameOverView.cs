using snake_windows_forms.Models;
using snake_windows_forms.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_windows_forms.View
{
    public partial class GameOverView : Form
    {
        int score = 0;
        FileManagement fm = new FileManagement();
        public GameOverView(int score)
        {
            InitializeComponent();
            this.score = score;
            scoreText.Text = "Your scores: " + score.ToString();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            fm.saveScore(score, nameTextBox.Text);
            this.Hide();
            using (var menu = new MainMenuView())
            {
                menu.StartPosition = FormStartPosition.Manual;
                menu.Location = this.Location;
                menu.Size = this.Size;
                menu.ShowDialog(this);
            }
        }
    }
}
