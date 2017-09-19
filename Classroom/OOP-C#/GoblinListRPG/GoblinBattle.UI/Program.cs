using System;
using System.Threading;

namespace GoblinBattle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            //Declare a new Character
            Human human = gm.Load();
            //Character a name
            human.Name = ConsoleIO.Prompt("Please Enter your name:");
            //Declare steps set to 0
            do
            {
                int steps = 0;
                while (steps < 10 )
                {
                    //Each Steps til 10, Call CreatureGenrator.RandomCreature()
                    Creature creature = CreatureGenerator.RandomCreature();
                    //if not null GoTo Battle
                    if (creature != null)
                    {
                        ConsoleIO.Display(creature.GetType().Name);
                        Battle(human, creature);
                    }
                    else
                    {
                        ConsoleIO.Display("No creature found, you are safe");
                    }

                    //if HP == 0 break loop
                    if (human.IsDead)
                    {
                        break;
                    }
                    human.TotalSteps++;
                    steps++;
                }
                if (human.IsDead == false)
                {
                    human.LevelUp();
                    ConsoleIO.Display("You've gained a level.");
                    if (ConsoleIO.Prompt("Do you want to save? Y/N").ToUpper() == "Y")
                    {
                        gm.Save(human);
                    }
                }
                //TODO: outside loop, display number steps
                Console.WriteLine("You've made it {0} steps.", human.TotalSteps);
            } while (human.IsDead == false && ConsoleIO.Prompt("Do you want to go to the next floor? Y/N").ToUpper() == "Y");

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }

        private static void Battle(Human human, Creature creature)
        {
            //Keep going until either human or creature isDead
            do
            {
                Thread.Sleep(1000);
                //Human Attack first, creature attacks if not dead second
                human.Attack(creature);
                if (creature.IsDead == false)
                {
                    creature.Attack(human);
                }
            } while (!human.IsDead && !creature.IsDead);
        }
    }
}
