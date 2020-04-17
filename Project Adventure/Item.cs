using System;
using System.Collections.Generic;

namespace Project_Adventure
{
    class Item
    {
        public string Name = "";
        public string Description = "";

        public string effect = ""; // health, attack
        public int maxEffect = 0;
        public int minEffect = 0;
        public int effectValue
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(minEffect, maxEffect + 1);
            }

            set { }
        }

        public int useTimes = 1;

        public void Use()
        {
            Game.Message($"You used your {Name}...");
            int current = effectValue;

            if (effect == "health")
            {
                Data.Health += current;
                if (Data.Health > Data.maxHealth)
                    Data.Health = Data.maxHealth;
                Game.Message($"You restored {current} health! You have {Data.Health}/{Data.maxHealth} health.");
            }

            else if (effect == "attack")
            {
                if (Data.Foes.Count == 0)
                {
                    Game.Message("There is no effect if you use it now...");
                }
                else
                {
                    List<string> choices = new List<string> { };
                    int index = 0;
                    foreach (Enemy foe in Data.Foes)
                    {
                        choices.Add($"({Game.Alphabet[index]}) {foe.Name} - {foe.health}/{foe.maxHealth}");
                    }

                    string[] aChoices = choices.ToArray();
                    string playerInput = Game.Choice("Which foe do you attack?", aChoices);
                    int enemyIndex = Array.IndexOf(Game.Alphabet, playerInput);
                    Data.Foes[enemyIndex].health -= effectValue;

                    Game.Message($"You damaged the {Data.Foes[enemyIndex]} by ");
                }
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
