using System;
using GoblinBattle.UI.Weapons;

namespace GoblinBattle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g1 = new Goblin();
            Goblin g2 = new Goblin();
            Stick holyStick = new Stick();
            holyStick.DmgModifier = 2;
            holyStick.Name = "Big Holy Stick";

            Sword rustySword = new Sword();
            rustySword.DmgModifier = 1;
            rustySword.Name = "A very rusty sword";
            
            g1.HitPoints = 10;
            g1.Name = "Bob";
            g1.WeaponSword = rustySword;
            
            g2.HitPoints = 10;
            g2.Name = "Tom";
            g2.WeaponStick = holyStick;

            // they should take turns attacking, goblin 1 will go first
            int whoseTurn = 1;

            while (!g1.IsDead && !g2.IsDead)
            {
                if (whoseTurn == 1)
                {
                    g1.Attack(g2);
                    whoseTurn = 2;
                }                    
                else
                {
                    g2.Attack(g1);
                    whoseTurn = 1;
                }
            }

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }
    }
}
