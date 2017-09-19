using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.UI
{
    public class GameManager
    {
        private const string SaveFile = "C:/GoblinBattle/Hero.txt";
        public void Save(Human human)
        {
            using (StreamWriter sw = new StreamWriter(SaveFile, false))
            {
                sw.WriteLine($"{human.Name},{human.HP},{human.TotalSteps}");
            }
        }
        public Human Load()
        {
            Human result = new Human();

            if (File.Exists(SaveFile) == false)
            {
                File.Create(SaveFile);
            }

            using (StreamReader sr =
                new StreamReader(SaveFile))
            {
                string characterData = sr.ReadLine();
                if (string.IsNullOrEmpty(characterData) == false)
                {
                    string[] fields = characterData.Split(',');
                    result = new Human(int.Parse(fields[1]));
                    result.Name = fields[0];
                    result.TotalSteps = int.Parse(fields[2]);
                }
            }

            return result;
        }
    }
}
