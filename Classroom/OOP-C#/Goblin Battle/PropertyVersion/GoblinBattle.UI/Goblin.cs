using System;
using GoblinBattle.UI.Weapons;

namespace GoblinBattle.UI
{
    class Goblin
    {
        // we only need one rng for all goblin instances, so static
        private static Random _rng = new Random();

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                // check incoming value
                if (value < 0)
                    return;
                else // otherwise save it to the field
                    _hitPoints = value;
            }
        }

        public Stick WeaponStick { get; set; }
        public Sword WeaponSword { get; set; }

        public string Name { get; set; }
        public bool IsDead { get; private set; }

        // attack another goblin instance (target)
        public void Attack(Goblin target)
        {
            int extraDamage = 0;
            if (this.WeaponSword != null)
            {
                extraDamage = this.WeaponSword.DmgModifier;
            }
            else if (this.WeaponStick != null)
            {
                extraDamage = this.WeaponStick.DmgModifier;
            }
            int damage = _rng.Next(5) + extraDamage;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            target.Hit(damage);
        }

        public void Attack(Goblin target, Stick stick)
        {
            int damage = _rng.Next(5) + stick.DmgModifier;
            Console.WriteLine($"{stick.Name} hits for{damage}!");
            target.Hit(damage);
        }

        public void Attack(Goblin target, Sword sword)
        {
            int damage = _rng.Next(5) + sword.DmgModifier;
            Console.WriteLine($"{sword.Name} hits for{damage}!");
            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            // deduct damage
            _hitPoints -= damage;
            Console.WriteLine($"{Name} receives {damage} damage. They have {_hitPoints} health.");

            // should we die?
            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{Name} has died!");
                IsDead = true;
            }
        }
    }
}
