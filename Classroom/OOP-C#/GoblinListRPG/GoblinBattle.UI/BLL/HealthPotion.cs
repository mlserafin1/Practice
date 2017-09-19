using System;

namespace GoblinBattle.UI
{
    public class HealthPotion : Potion
    {
        public override void Drink(Creature creature)
        {
            Console.WriteLine("This has healed you");
            creature.Hit(-5);
        }
    }
}