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

            Character player = new(); // Create new player character.

            CollectCharacterInformation(out string name, out string location, out string gender);

            player.Name = name;
            player.Location = location;
            player.Gender = gender;
            player.IsAlive = true;

            Console.Clear();

            // Adventure Start. (WIP)

            WriteText($"It is a dark and stormy night in the town of {towns[0]}. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you've decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but is bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your sword. Your bag rests atop the nightstand.\n\nWhat will you do?\n");

            // Game will prompt user for input. Based on input, do a specific action. If the character dies the game ends. (WIP)

            while (player.IsAlive)
            {
                string? input = ValidateAndGetInput();

                if (input == "grab" || input == "Grab")
                {
                    WriteText("What? Grab the air? You must choose an object.\n");
                }
                else
                {
                    WriteText("What? Ye have to speak clearer.\n");
                }
            }

            // Character dies... The program ends.

            Console.Write($"\nYou have died! Fare thee well, {player.Name}.\n\nPress any key to exit the game...\n");

            Console.ReadKey(true);

            Environment.Exit(0);
        }

        public static void IntroToMeridia() // Start of the game.
        {
            WriteText($"Welcome, adventurer, to the world of {worldName}.\n\nPress any key to start your adventure...");

            Console.ReadKey(true);
        }

        public static void CollectCharacterInformation(out string name, out string location, out string gender)
        {
            WriteText("What be your name, traveler?\n");

            name = ValidateAndGetInput(); // Checks if null. If null then prompts to enter another value.

            WriteText($"\nGreetings, {name}. From where do you hail?\n");

            location = ValidateAndGetInput(); // Checks if null. If null then prompts for another value.

            if (location == "Steelswamp" || location == "steelswamp") // Flavor text for if player enters in game location.
            {
                WriteText($"\nAh, rainy ol' {location}. creepy place, that is. There be a strange inn there.\n");
            }
            else if (location == "Ironhold" || location == "ironhold")
            {
                WriteText($"\nAh, busy ol' {location}. Scary place, that is. They make weapons there.\n");
            }
            else if (location == "Meadowland" || location == "meadowland")
            {
                WriteText($"\nAh, peaceful ol' {location}. Relaxing place, that is. They sell medicinal herbs there.\n");
            }
            else if (location == "Forestview" || location == "forestview")
            {
                WriteText($"\nAh, quiet ol' {location}. Interesting place, that is. They make nice bows there.\n");
            }
            else if (location == "Groverest" || location == "groverest")
            {
                WriteText($"\nAh, good ol' {location}. Historical place, that is. The first Holy Church was built there.\n");
            }
            else if (location == "Meridia" || location == "meridia")
            {
                WriteText("\nOh, ye think ye smart? Where else would ye be from?\n");
            }
            else
            {
                Program.WriteText("\nNever heard o' there before, but alright then.\n"); // End of flavor text.
            }

            WriteText($"\n{name} of {location}. That has a nice ring to it, doesn't it? Now, are ye a lass or lad?\n");

            gender = ValidateAndGetInput(); // Checks if null. If null then prompts for another value.

            WriteText("\nAlright. Let's get this adventure started.\n\nPress any key to continue...");

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
                Console.Write("Nothing was entered.\n");
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
                    Console.Write("Answer must not contain a number.\n");
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
                Console.Write($"Answer must be between {minimumInputLength}-{maximumInputLength} characters.\n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}