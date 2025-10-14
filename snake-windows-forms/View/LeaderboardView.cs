using snake_windows_forms.Models;
using snake_windows_forms.Persistence;
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
    public partial class LeaderboardView : Form
    {
        public List<Scores> scoresList = new List<Scores>();
        public FileManagement fm = new FileManagement();
        public LeaderboardView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                scoresList = fm.loadScores();
                scoresListBox.Items.Clear();
                foreach (var s in scoresList)
                    scoresListBox.Items.Add($"{s.name} {s.score}");
            }
            catch { }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
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
