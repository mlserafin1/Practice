using System;

namespace GoblinBattle.UI
{
    class CreatureGenerator
    {

        public static Creature RandomCreature()
        {
            Random rng = new Random();
            Creature result;
            switch (rng.Next(1, 4))
            {
                case 1:
                    result = new Troll() {Name = "Evil Troll"};
                    break;
                case 2:
                    result = new Goblin() {Name = "Nasty Goblin"};
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}