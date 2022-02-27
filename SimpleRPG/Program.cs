class SimpleRPG
{
    private static string?[] playerChoices = new string[3];
    private static string worldName = "Meridia";
    public static void Main()
    {
        //Intro

        WriteText($"Welcome, adventurer, to the world of {worldName}.\n\nPress any key to start your adventure...");
        Console.ReadKey(true);

        // Collect character information.

        Console.Clear();

        WriteText("What be your name, traveler?");
        bool nameIsNull = true;

        playerChoices[0] = ValidateInput(playerChoices[0], nameIsNull); // Checks if null. If null then prompts to enter another value.

        WriteText($"\nGreetings, {playerChoices[0]}. From where do you hail?");
        bool homeIsNull = true;

        playerChoices[1] = ValidateInput(playerChoices[1], homeIsNull); // Checks if null. If null then prompts for another value.

        WriteText($"\n{playerChoices[0]} of {playerChoices[1]}. That has a ring to it, doesn't it? Now, are ye a lass or lad?");
        bool pronounChoiceIsNull = true;

        playerChoices[2] = ValidateInput(playerChoices[2], pronounChoiceIsNull); // Checks if null. If null then prompts for another value.

        WriteText("\nAlright. Let's get this adventure started.\n\nPress any key to continue...");
        Console.ReadKey(true);

        // Adventure Start

        Console.Clear();

        WriteText("It is a dark and stormy night in the town of Steelswamp. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your sword. Your bag rests atop the nightstand.");
    }
    public static string? GetText() => Console.ReadLine(); // Get user input.
    public static void WriteText(string input) // Used for "typing" effect on RPG prompts.
    {
        foreach (char ch in input)
        {
            Console.Write(ch);
            Thread.Sleep(50);
        }
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
    public static string? ValidateInput(string? inputChoice, bool inputIsNull) // Prompts if field is null. Takes nullable type string and boolean value.
    {
        do
        {
            Console.Write("\nPlease enter an answer: ");
            inputChoice = GetText();
            inputIsNull = IsInputNull(inputChoice);
            continue;
        }
        while (inputIsNull);
        return inputChoice;
    }
}
