using System;

namespace GoblinBattle.UI
{
    public class PoisonPotion : Potion
    {
        public override void Drink(Creature creature)
        {
            Console.WriteLine("This has hurt you, why did you drink me");
            creature.Hit(5);
        }
    }
}