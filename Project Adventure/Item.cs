using System;

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
                Data.Items.Remove(this);
            }
            else
            {
                Game.Message($"You can use your {Name} {useTimes} more time(s).");
            }
        }

        public void Announce()
        {
            Game.Message($"You got a {Name}!");
            Game.Message($"{Name}: {Description}", Color.Magenta);
        }
    }
}
