class SimpleRPG
{
    private readonly static string?[] playerChoices = new string[3]; // 0: Name, 1: location, 2: pronoun choice.
    private readonly static string[] towns = { "Steelswamp", "Ironhold", "Meadowland", "Forestview", "Groverest" };
    private readonly static string worldName = "Meridia";
    public static void Main()
    {
        //Intro

        IntroToMeridia();

        // Collect character information.

        CollectCharacterInformation();

        // Adventure Start. (WIP)

        Console.Clear();

        WriteText($"It is a dark and stormy night in the town of {towns[0]}. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your sword. Your bag rests atop the nightstand.");

        // Game will prompt user for input. Based on input, do a specific action. (WIP)
    }
    public static void IntroToMeridia()
    {
        WriteText($"Welcome, adventurer, to the world of {worldName}.\n\nPress any key to start your adventure...");
        Console.ReadKey(true);
    }
    public static void CollectCharacterInformation()
    {
        Console.Clear();

        WriteText("What be your name, traveler?");

        playerChoices[0] = ValidateInput(); // Checks if null. If null then prompts to enter another value.

        WriteText($"\nGreetings, {playerChoices[0]}. From where do you hail?");

        playerChoices[1] = ValidateInput(); // Checks if null. If null then prompts for another value.

        WriteText($"\n{playerChoices[0]} of {playerChoices[1]}. That has a nice ring to it, doesn't it? Now, are ye a lass or lad?");

        playerChoices[2] = ValidateInput(); // Checks if null. If null then prompts for another value.

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
    public static string? ValidateInput() // Prompts if field is null, numeric, or not between 3-15.
    {
        bool inputIsNull = false;
        bool inputIsNumeric = false;
        bool inputIsCorrectLength = true;
        string? inputChoice;

        do
        {
            Console.Write("\nPlease enter an answer: ");

            inputChoice = Console.ReadLine();
            inputIsNull = IsInputNull(inputChoice);

            if (inputIsNull)
            {
                continue;
            }

            inputIsNumeric = IsNumeric(inputChoice);

            if (inputIsNumeric)
            {
                continue;
            }

            inputIsCorrectLength = IsInputCorrectLength(inputChoice);

            if (!inputIsCorrectLength)
            {
                continue;
            }
        }
        while (inputIsNull || inputIsNumeric || !inputIsCorrectLength);

        return inputChoice;
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
    public static bool IsNumeric(string? inputChoice) // Checks if field is numeric. Takes nullable type string.
    {
        foreach (char ch in inputChoice)
        {
            if (!Char.IsLetter(ch))
            {
                Console.Write("Answer must not contain a number.");
                return true;
            }
        }

        return false;
    }
    public static bool IsInputCorrectLength(string? inputChoice) // Checks if field is between 3-15. Takes nullable type string.
    {
        int minimumInputLength = 3;
        int maximumInputLength = 15;

        if (inputChoice.Length < minimumInputLength || inputChoice.Length > maximumInputLength)
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
