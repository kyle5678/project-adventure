using System;
using System.Collections.Generic;

namespace Project_Adventure
{
    class Item
    {
        public string Name = "";
        public string Description = "";

        public string Effect
        {
            get { return _effect; }
            set
            {
                if (Array.Exists(Game.ValidItemEffects, e => e == value))
                    _effect = value;
                else
                    throw new Exception("/ Invalid Item Effect /");
            }
        }
        private string _effect = "";

        public int MaxEffect = 0;
        public int MinEffect = 0;

        public int effectValue
        {
            get
            {
                Random rnd = new Random();
                return rnd.Next(MinEffect, MaxEffect + 1);
            }

            set { }
        }

        public int useTimes = 1;

        public void Use()
        {
            bool used = true;

            Game.Message($"You used your {Name}...");
            int current = effectValue;

            if (Effect == "health")
            {
                Data.Health += current;
                if (Data.Health > Data.maxHealth)
                    Data.Health = Data.maxHealth;
                Game.Message($"You restored {current} health! You have {Data.Health}/{Data.maxHealth} health.");
            }

            else if (Effect == "attack")
            {
                if (Data.Foes.Count == 0)
                {
                    Game.Message("There is no effect if you use it now...");
                    used = false;
                }
                else
                {
                    List<string> choices = new List<string> { };
                    int index = 0;
                    foreach (Enemy foe in Data.Foes)
                    {
                        choices.Add($"({Game.Alphabet[index]}) {foe.Name} - {foe.Health}/{foe.MaxHealth}");
                        index++;
                    }

                    string[] aChoices = choices.ToArray();
                    string playerInput = Game.Choice("Which foe do you attack?", aChoices);
                    int enemyIndex = Array.IndexOf(Game.Alphabet, playerInput);
                    int damage = effectValue;
                    Data.Foes[enemyIndex].Health -= damage;

                    Game.Message($"You damaged the {Data.Foes[enemyIndex].Name} by {damage}!");
                    Data.Foes[enemyIndex].Die();
                }
            }

            else if (Effect == "retreat")
            {
                int chanceRoll = Game.rnd.Next(1, 101);

                if (Data.Foes.Count == 0)
                {
                    Game.Message("There are no enemies to retreat from.");
                    used = false;
                }
                else if (Game.BattleRetreatable)
                {
                    if (chanceRoll <= effectValue)
                    {
                        Game.Message("You successfully retreated from the battle!");
                        foreach (Enemy foe in Data.Foes.ToArray())
                        {
                            Data.Foes.Remove(foe);
                        }
                    }
                    else
                        Game.Message("Your attempt to retreat was discovered.");
                }
                else
                {
                    Game.Message("You cannot retreat from this battle.");
                    used = false;
                }
            }

            else
                Game.Message($"But nothing happened...");

            if (used)
            {
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
        }

        public void Announce()
        {
            Game.Message($"You got a {Name}!");
            Game.Message($"{Name}: {Description}", Color.Magenta);
        }
    }
}
