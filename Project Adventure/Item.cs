using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    class Item
    {
        public string Name = "";
        public string Description = "";
        public string effect = ""; // health
        public int effectValue = 0;
        public int useTimes = 1;

        public void Use()
        {
            Game.Message($"You used your {Name}...");
            if (effect == "health")
            {
                Data.Health += effectValue;
                if (Data.Health > Data.maxHealth)
                    Data.Health = Data.maxHealth;
                Game.Message($"You restored {effectValue} health! You have {Data.Health}/{Data.maxHealth} health.");
            }
            else
                Game.Message($"But nothing happened...");

            if (--useTimes == 0)
            {
                Game.Message($"You can no longer use your {Name}.");
                foreach (Item testing in Data.Items)  // make this better, if possible
                {
                    if (testing.useTimes == 0)
                        Data.Items.Remove(testing); break;
                }
            }
            else
            {
                Game.Message($"You can use your {Name} {useTimes} more time(s).");
            }
        }

        public void Announce()
        {
            Game.Message($"You got a {Name}!");
            Game.Message(Description);
        }
    }
}
