using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.UI
{
    public abstract class Potion
    {
        public string Name { get; set; }
        public abstract void Drink(Creature creature);
    }
}
