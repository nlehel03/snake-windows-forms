﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_windows_forms.Models
{
    public class Scores
    {
        public string name;
        public int score;

        public Scores()
        {
            name = "";
            score = 0;
        }
        public Scores(string n, int s)
        {
            name = n;
            score = s;
        }
    }
}
