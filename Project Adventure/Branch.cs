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
            Game.StoryMessage("You wake up on a soft bed, light streaming through the windows nearby.");
            Game.StoryMessage("Where are you? You get out of bed and peer through a window.");
            Game.StoryMessage("You seem to be in a small village, with children playing outside");
            Game.StoryMessage("A door behind you creaks open. Someone comes in.");
            Game.CharacterSays("???", "So, you finally decided to wake up?", Color.Blue);
            Game.StoryMessage("You silently nod. You wonder who this woman is. You also wonder who you are.");
            Input.Name = Game.CharacterAsk("???", "So, what's your name?", Color.Blue);
            Game.CharacterSays("???", $"So your name is {Input.Name}, eh? Interesting...", Color.Blue);
            Game.CharacterSays("???", $"Well, my name's Magda. Nice to meet you, {Input.Name}. Breakfast's ready outside.", Color.Blue);

            Game.Line();

            Game.StoryMessage("You leave the bedroom and meet Magda outside the house.");
            Game.StoryMessage("The villagers are all having breakfast together. You sit down to join them.");
            Game.CharacterSays("Villager", "Hey, it's the new one!", Color.Blue);
            Game.CharacterSays("Other Villager", "So, you finally woke up, huh?", Color.Blue);
            Game.CharacterSays("Yet Another Villager", "Why did you come here? Are you one of them? A spy?", Color.Blue);
            Game.CharacterSays("Magda", "Oi! Leave him alone! He's done nothing wrong to you.", Color.Green);
            Game.CharacterSays("Villager from Before", "What if he's a spy?", Color.Blue);
            Game.CharacterSays("Magda", "Well, if he is, then he's a spy who is tired and in need of a rest, and we can be the ones to provide him with that.", Color.Green);
            Game.StoryMessage("Finally, the villagers leave you alone. You start to eat what's in front of you, a sandwich.");
            Game.CharacterSays("Magda", "Don't worry about Steve and the others. That's just their way of saying hello!", Color.Green);
            Game.StoryMessage("You silently nod, but wonder if those aggressive villagers were really just saying hello.");
            Game.CharacterSays("Magda", "You're in the humble village of /addnamelaterpleaseeditorweareunnamed/", Color.Green);
            Game.StoryMessage("You politely ask Magda about what spies the villagers were talking about before.");
            Game.CharacterSays("Magda", "The villagers are all scared of an evil force from outer space we call the Conquerers. Everyone suspects you are a spy of theirs.", Color.Green);
            Game.CharacterSays($"You ({Input.Name})", "But I'm not!", Color.Magenta);
            Game.CharacterSays("Magda", "Mistrust has been a part of our everyday life for years now.", Color.Green);
            Game.CharacterSays("Magda", $"But of course, I trust you, {Input.Name}.", Color.Green);
            Game.StoryMessage("You are glad for Magda's trust, but are left wondering whether anyone else - other than her - trusts you.");

            Game.Line();

            Game.StoryMessage("After a few more days of peaceful village life, more and more people start to trust you.");
            Game.StoryMessage("But still, your past is clouded and unreachable.");
            Game.StoryMessage("You consider going out on your own - in hopes that you will discover your past - but you decide no.");
            Game.StoryMessage("Yet you cannot keep your mind off of that idea. You wonder if you do want to go on an adventure.");

            string choice = Game.Choice("Do you?", new string[] { "A: Discover your past", "B: Stay in the village." });
            if (choice == "A")
                Current = "A1";
            else if (choice == "B")
                Current = "A2";
            else
                throw new Exception("// Error: Invalid Choice ID //");
        }

        public static void A1()
        {
            Game.StoryMessage("You start to pack your bags.");
            Game.StoryMessage("Magda comes in and sees this.");
            Game.CharacterSays("Magda", "What are you doing?", Color.Blue);
            Game.CharacterSays($"You ({Input.Name})", "I need to find out about my past.", Color.Magenta);
            Game.CharacterSays("Magda", "This early? You've only been here a week!", Color.Blue);
            Game.CharacterSays($"You ({Input.Name})", "I can't stay here forever.", Color.Magenta);
            Game.CharacterSays("Magda", "Well, at least stay here another month!", Color.Blue);
            Game.CharacterSays($"You ({Input.Name})", "Sorry, but I must go. See you soon!", Color.Magenta);
            Game.StoryMessage("And with that, you ");
        }

        public static void A2()
        {
            Game.StoryMessage("You lived a happy unknowing life in the village.");
            Game.StoryMessage("Though your mind still wanders...");
            Game.StoryMessage("You wonder if you could've gone on that adventure.");
            Game.StoryMessage("You wish you had. Although you are content with what you have here, you never discover anything...");

            Current = "";
        }
    }
}
