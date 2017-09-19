using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.UI
{
    public class Human : Creature
    {
        public Potion[] Potions { get; set; }
        public int TotalSteps { get; set; }

        public Human()
        {
            
        }
        public Human(int hp)
        {
            HP = hp;
        }
        public void LevelUp()
        {
            this.HP += 5;
        } 
    }
}
