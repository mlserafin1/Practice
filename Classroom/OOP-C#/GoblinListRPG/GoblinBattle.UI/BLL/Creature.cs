using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.UI
{
    public class Creature
    {
        private static Random _rng = new Random();

        protected int _hp;

        public Creature()
        {
            HP = 5;
        }

        public bool IsDead { get; private set; }
        public string Name { get; set; }

        public int HP
        {
            get { return _hp; }
            protected set
            {
                if (value < 0)
                {
                    _hp = 0;
                }
                else
                {
                    _hp = value;
                }
            }
        }
        // attack another goblin instance (target)
        public void Attack(Creature target)
        {

            int damage = _rng.Next(5);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {

            // deduct damage

            HP -= damage;
            Console.WriteLine($"{Name} receives {damage} damage. They have {HP} health.");
            if (HP == 0)
            {
                Console.WriteLine($"{Name} has died!");
                IsDead = true;
            }

        }
    }
}
