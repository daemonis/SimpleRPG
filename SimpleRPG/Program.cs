namespace SimpleRPG
{
    class Program
    {
        private readonly static string[] towns = { "Steelswamp", "Ironhold", "Meadowland", "Forestview", "Groverest" };
        private readonly static string worldName = "Meridia";
        public static void Main()
        {
            //Intro

            IntroToMeridia();

            Console.Clear();

            // Collect character information.

            CollectCharacterInformation();

            Console.Clear();

            // Adventure Start. (WIP)

            WriteText($"It is a dark and stormy night in the town of {towns[0]}. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but is bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your sword. Your bag rests atop the nightstand.");

            // Game will prompt user for input. Based on input, do a specific action. (WIP)
        }
        public static void IntroToMeridia()
        {
            WriteText($"Welcome, adventurer, to the world of {worldName}.\n\nPress any key to start your adventure...");

            Console.ReadKey(true);
        }
        public static void CollectCharacterInformation()
        {
            Character player = new Character();

            WriteText("What be your name, traveler?");

            player.Name = ValidateAndGetInput(); // Checks if null. If null then prompts to enter another value.

            WriteText($"\nGreetings, {player.Name}. From where do you hail?");

            player.Location = ValidateAndGetInput(); // Checks if null. If null then prompts for another value.

            WriteText($"\n{player.Name} of {player.Location}. That has a nice ring to it, doesn't it? Now, are ye a lass or lad?");

            player.Gender = ValidateAndGetInput(); // Checks if null. If null then prompts for another value.

            WriteText("\nAlright. Let's get this adventure started.\n\nPress any key to continue...");

            player.Level = 1;

            Console.ReadKey(true);
        }
        public static void WriteText(string input) // Used for "typing" effect on RPG prompts. Takes type string.
        {
            foreach (char ch in input)
            {
                Console.Write(ch);
                Thread.Sleep(50);
            }
        }
        public static string? ValidateAndGetInput() // Prompts if field is null, numeric, or not between 3-15.
        {
            bool inputIsNull = false, inputIsNumeric = false, inputIsCorrectLength = true;
            string? input;

            do
            {
                Console.Write("\nPlease enter an answer: ");

                input = Console.ReadLine();

                inputIsNull = IsInputNull(input);

                if (inputIsNull)
                {
                    continue;
                }

                inputIsNumeric = IsNumeric(input);

                if (inputIsNumeric)
                {
                    continue;
                }

                inputIsCorrectLength = IsInputCorrectLength(input);

                if (!inputIsCorrectLength)
                {
                    continue;
                }
            }
            while (inputIsNull || inputIsNumeric || !inputIsCorrectLength);

            return input;
        }
        public static bool IsInputNull(string? input) // Checks if field is null. Takes nullable type string.
        {
            if (String.IsNullOrEmpty(input))
            {
                Console.Write("Nothing was entered.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsNumeric(string? input) // Checks if field is numeric. Takes nullable type string.
        {
            foreach (char ch in input)
            {
                if (!Char.IsLetter(ch))
                {
                    Console.Write("Answer must not contain a number.");
                    return true;
                }
            }
            return false;
        }
        public static bool IsInputCorrectLength(string? input) // Checks if field is between 3-15. Takes nullable type string.
        {
            int minimumInputLength = 3;
            int maximumInputLength = 15;

            if (input.Length < minimumInputLength || input.Length > maximumInputLength)
            {
                Console.Write($"Answer must be between {minimumInputLength}-{maximumInputLength} characters.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}