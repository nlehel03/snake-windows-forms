using snake_windows_forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_windows_forms.Persistence
{
    public class FileManagement
    {
        List<MapSize> mapSizeList = new List<MapSize>();
        Scores sc;
        public FileManagement() 
        {
            
        }
        public MapSize loadMapSize(int x)
        {
            StreamReader sr = new StreamReader("mapsize.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] parts = line.Split(';');
                MapSize ms= new MapSize(int.Parse(parts[0]), int.Parse(parts[1]));
                mapSizeList.Add(ms);
            }
            return mapSizeList[x];
        }
        public List<Scores> loadScores()
        {
            List<Scores> scoresList = new List<Scores>();
            StreamReader sr = new StreamReader("scores.txt");
            sc = new Scores();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] temp = line.Split(";");
                sc.name = temp[0];
                sc.score = int.Parse(temp[1]);
                scoresList.Add(sc);
            }
            sr.Close();
            return scoresList;
        }
        public void saveScore(int s,string n)
        {
            List<Scores> slist = loadScores();
            sc.name = n;
            sc.score = s;
            slist.Add(sc);
            slist.Sort();
            StreamWriter sw = new StreamWriter("scores.txt");
            for(int i = 0; i< slist.Count; i++)
            {
                sw.WriteLine(sc.name + ";" + sc.score);
            }
            sw.Flush();
            sw.Close();

        }
    }
}
