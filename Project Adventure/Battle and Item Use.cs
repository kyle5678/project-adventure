using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    static partial class Game
    {
        public static bool BattleRetreatable;
        public static void Battle(bool retreatable = true)
        {
            BattleRetreatable = retreatable;

            Line();
            Message("Battle commences!", Color.Red);

            while (Data.Health > 0 && Data.Foes.Count != 0)
            {
                // PLAYER'S TURN
                UseItem();

                // ENEMIES' TURN
                foreach (Enemy foe in Data.Foes)
                {
                    foe.Attack();
                }
            }

            if (Data.Health == 0)
            {
                Message("Your foes have defeated you!");
                Story.Current = "";
            }

            else
            {
                if (Data.LastUsedItem.Effect != "retreat")
                {
                    Message($"You won the battle, with {Data.Health}/{Data.maxHealth} remaining!");
                }
            }
        }

        public static void UseItem()
        {
            List<string> Choices = new List<string>();
            int index = 0;
            foreach (Item item in Data.Items)
            {
                Choices.Add($"({Alphabet[index]}) {item.Name}: {item.Description}");
                index++;
            }
            int ItemChoice = Array.IndexOf(Alphabet, Choice("What item do you use?", Choices.ToArray()));
            Data.LastUsedItem = Data.Items[ItemChoice];
            Data.Items[ItemChoice].Use();
        }
    }
}
