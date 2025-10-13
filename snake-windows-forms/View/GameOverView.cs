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
    public partial class GameOverView : Form
    {
        int score;
        public GameOverView(int score)
        {
            InitializeComponent();
            this.score = score;
        }
    }
}
