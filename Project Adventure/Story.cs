using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    class Story
    {
        public static string Current = "Base";

        public static void Base()
        {
            Game.Message("You wake up on a soft bed, light streaming through the windows nearby.");
            Game.Message("Where are you? You get out of bed and peer through a window.");
            Game.Message("You seem to be in a small village, with children playing outside");
            Game.Message("A door behind you creaks open. Someone comes in.");
            Game.Dialogue("???", "So, you finally decided to wake up?", Color.Blue);
            Game.Message("You silently nod. You wonder who this woman is. You also wonder who you are.");
            Data.Name = Game.Ask("???", "So, what's your name?", Color.Blue);
            Game.Dialogue("???", $"So your name is {Data.Name}, eh? Interesting...", Color.Blue);
            Game.Dialogue("???", $"Well, my name's Magda. Nice to meet you, {Data.Name}. Breakfast's ready outside.", Color.Blue);

            Game.Line();

            Game.Message("You leave the bedroom and meet Magda outside the house.");
            Game.Message("The villagers are all having breakfast together. You sit down to join them.");
            Game.Dialogue("Villager", "Hey, it's the new one!", Color.Blue);
            Game.Dialogue("Other Villager", "So, you finally woke up, huh?", Color.Blue);
            Game.Dialogue("Yet Another Villager", "Why did you come here? Are you one of them? A spy?", Color.Blue);
            Game.Dialogue("Magda", "Oi! Leave him alone! He's done nothing wrong to you.", Color.Green);
            Game.Dialogue("Villager from Before", "What if he's a spy?", Color.Blue);
            Game.Dialogue("Magda", "Well, if he is, then he's a spy who is tired and in need of a rest, and we can be the ones to provide him with that.", Color.Green);
            Game.Message("Finally, the villagers leave you alone. You start to eat what's in front of you, a sandwich.");
            Game.Dialogue("Magda", "Don't worry about Steve and the others. That's just their way of saying hello!", Color.Green);
            Game.Message("You silently nod, but wonder if those aggressive villagers were really just saying hello.");
            Game.Dialogue("Magda", "You're in the humble village of /addnamelaterpleaseeditorweareunnamed/", Color.Green);
            Game.Message("You politely ask Magda about what spies the villagers were talking about before.");
            Game.Dialogue("Magda", "The villagers are all scared of an evil force from outer space we call the Conquerers. Everyone suspects you are a spy of theirs.", Color.Green);
            Game.Dialogue($"You ({Data.Name})", "But I'm not!", Color.Magenta);
            Game.Dialogue("Magda", "Mistrust has been a part of our everyday life for years now.", Color.Green);
            Game.Dialogue("Magda", $"But of course, I trust you, {Data.Name}.", Color.Green);
            Game.Message("You are glad for Magda's trust, but are left wondering whether anyone else - other than her - trusts you.");

            Game.Line();

            Game.Message("After a few more days of peaceful village life, more and more people start to trust you.");
            Game.Message("But still, your past is clouded and unreachable.");
            Game.Message("You consider going out on your own - in hopes that you will discover your past - but you decide no.");
            Game.Message("Yet you cannot keep your mind off of that idea. You wonder if you do want to go on an adventure.");

            string choice = Game.Choice("Do you?", new string[] { "(A) Discover your past", "(B) Stay in the village." });
            if (choice == "A")
                Current = "A1";
            else if (choice == "B")
                Current = "A2";
            else
                throw new Exception("// Error: Invalid Choice ID //");
            Game.Line();
        }

        public static void A1()
        {
            Game.Message("You start to pack your bags.");
            Game.Message("Magda comes in and sees this.");
            Game.Dialogue("Magda", "What are you doing?", Color.Blue);
            Game.Dialogue($"You ({Data.Name})", "I need to find out about my past.", Color.Magenta);
            Game.Dialogue("Magda", "This early? You've only been here a week!", Color.Blue);
            Game.Dialogue($"You ({Data.Name})", "I can't stay here forever.", Color.Magenta);
            Game.Dialogue("Magda", "Well, at least stay here another month!", Color.Blue);
            Game.Dialogue($"You ({Data.Name})", "Sorry, but I must go. See you soon!", Color.Magenta);
            Game.Message("And with that, you run off, in search of hints of your past life.");

            Game.Line();

            Game.Message("After several hours of walking, you sit down to take a rest.");
            Game.Message("You take out a sandwich you packed earlier.");
            Game.Message("While you munch on your delicious food, you see a shadow moving in a grove of trees close by.");

            string choice = Game.Choice("Do you investigate?", new string[] { "(A) Yes", "(B) No" });
            if (choice == "A")
            {
                Game.Message("You silently walk over to the small grove.");
                Game.Message("You hear a surprised \"squeak!\" and hear the small creature scurry away.");
                Game.Message("It left something behind though.");

                Item acornItem = new Item
                {
                    Name = "Acorn",
                    Description = "A small acorn found on the ground commonly near trees. Restores 2 health.",
                    Effect = "health",
                    MaxEffect = 2,
                    MinEffect = 2,
                    useTimes = 1
                };
                Game.Manage(acornItem);

                Game.Message("You put the acorn in your bag and pack up to continue your journey.");
            }
            if (choice == "B")
                Game.Message("You finish up your sandwich and continue your trek.");

            Game.Line();
            Game.Message("Nighttime falls.");
            Game.Message("You have a tent in your bag, if you want to have a rest.");
            Game.Message("You feel really tired, but you have an urge to look around and see what you can find in the night.");

            choice = Game.Choice("What do you do now?", new string[] { "(A) Set up camp for the night (Heals all health)", "(B) Go and explore" });
            if (choice == "A")
            {
                Game.Camp();
                Game.Message("That was a good rest. You wake up feeling energized, healthy, and rested.");
                Game.Message("You pack up your tent and prepare for the walk ahead.");
            }
            if (choice == "B")
            {
                Game.Message("You go and explore the forest.");
                Game.Message("A small gust of wind shakes a tree branch off a tree.");

                Item branchItem = new Item
                {
                    Name = "Branch",
                    Description = "A common tree branch that fell from a tree. Possibly could be used as a crude weapon.",
                    Effect = "attack",
                    MinEffect = 2,
                    MaxEffect = 5,
                    useTimes = 64
                };
                Game.Manage(branchItem);

                Game.Message("Rustling in the bushes nearby. What's there?");
                Game.Message("A beast springs out of the bush!!");

                Data.Foes.Add(new Enemy
                {
                    Name = "Shadow Servant",
                    Health = 10,
                    MaxHealth = 10,
                    MaxAttack = 3,
                    MinAttack = 1,
                    Reward = new Item
                    {
                        Name = "Retreat Gem",
                        Description = "Gives you a 35% chance to retreat from battle.",
                        Effect = "retreat",
                        MinEffect = 35,
                        MaxEffect = 35,
                        useTimes = 10,
                    }
                });

                Game.Battle();
                if (Data.Health == 0)
                    return;

                Game.Line();
                Game.Message("The battle took the entirety of the nighttime for some reason.");
            }

            Game.Message("You continue your trek.");
            Game.Message("Wait...");
            Game.Message("What's that?");
            Game.Message("There's something in the distance. A bright white light, a beacon, shining into the sky.");
            Game.Message("You look around, and notice a smoke signal to your right. Someone might need help!");
        }

        public static void A2()
        {
            Game.Message("You lived a happy unknowing life in the village.");
            Game.Message("Though your mind still wanders...");
            Game.Message("You wonder if you could've gone on that adventure.");
            Game.Message("You wish you had. Although you are content with what you have here, you never discover anything...");

            Current = "";
        }
    }
}
