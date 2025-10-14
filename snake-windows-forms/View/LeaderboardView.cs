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
        public FileManagement fm= new FileManagement();
        public LeaderboardView()
        {
            InitializeComponent();
            scoresList = fm.loadScores();
            for(int i = 0; i < scoresList.Count; i++)
            {
                scoresListBox.Items.Add(scoresList[i].name + " " + scoresList[i].score);
            }
        }
    }
}
