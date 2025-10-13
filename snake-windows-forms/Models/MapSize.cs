using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_windows_forms.Models
{
    public class MapSize
    {
        public int cellSize;
        public int n;
        public MapSize(int c, int n)
        {
            cellSize = c;
            this.n = n;
        }
    }
}
