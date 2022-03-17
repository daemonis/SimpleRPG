namespace SimpleRPG;

class Program
{
    private readonly static string worldName = "MERIDIA";

    private static readonly Town steelSwamp = new("STEELSWAMP", null, "Ah, rainy ol' STEELSWAMP. creepy place, that is. There be a strange inn there.");
    private static readonly Town ironHold = new("IRONHOLD", null, "Ah, busy ol' IRONHOLD. Scary place, that is. They make weapons there.");
    private static readonly Town meadowLand = new("MEADOWLAND", null, "Ah, peaceful ol' MEADOWLAND. Relaxing place, that is. They sell medicinal herbs there.");
    private static readonly Town forestView = new("FORESTVIEW", null, "Ah, quiet ol' FORESTVIEW. Interesting place, that is. They make nice bows there.");
    private static readonly Town groveRest = new("GROVEREST", null, "Ah, good ol' GROVEREST. Historical place, that is. The first Holy Church was built there.");

    private readonly static List<Town> towns = new() { steelSwamp, ironHold, meadowLand, forestView, groveRest };

    private static readonly Item sword = new("SWORD", 1, 0);
    private static readonly Item bag = new("BAG", 0, 0);
    private static readonly Item armor = new("ARMOR", 0, 2);
    private static readonly Item shield = new("SHIELD", 0, 1);

    private static readonly List<Item> itemList = new() { sword, bag, armor, shield };

    private static readonly string grabAction = "GRAB";
    private static readonly string inventoryAction = "INVENTORY";
    private static readonly string moveAction = "MOVE";
    private static readonly string helpAction = "HELP";
    private static readonly string clearAction = "CLEAR";

    private static readonly List<string> playerActions = new() { grabAction, inventoryAction, moveAction, helpAction, clearAction };

    public static void Main()
    {
        //Intro

        IntroToMeridia();

        Console.Clear();

        // Collect character information.

        Character player = new(); // Create new player character.
        player.IsAlive = true;
        player.Inventory = new List<Item>();
        player.CurrentTown = steelSwamp;

        CollectCharacterInformation(player);

        Console.Clear();

        // Adventure Start. (WIP)

        WriteText($"It is a dark and stormy night in the town of {steelSwamp.Name}. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you've decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but is bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your sword. Your bag rests atop the nightstand.\n\nWhat will you do?");

        // Game will prompt user for input. Based on input, do a specific action. If the character dies the game ends. (WIP)

        while (player.IsAlive)
        {
            string? input = ValidateAndGetInput();

            PlayerAction(input, player);
        }

        // Character dies... The program ends.

        Console.Write($"\nYou have died! Fare thee well, {player.Name}.\n\nPress any key to exit the game...");

        Console.ReadKey(true);

        Environment.Exit(0);
    }

    public static void IntroToMeridia() // Start of the game.
    {
        WriteText($"Welcome, adventurer, to the world of {worldName}.\n\nPress any key to start your adventure...");

        Console.ReadKey(true);
    }

    public static void CollectCharacterInformation(Character player) // Collects character information.
    {
        WriteText("What be your name, traveler?");

        player.Name = ValidateAndGetInput().ToUpper(); // Checks if null. If null then prompts to enter another value.

        WriteText($"\nGreetings, {player.Name}. From where do you hail?");

        string homeTownName = ValidateAndGetInput().ToUpper(); // Checks if null. If null then prompts for another value.

        Town? homeTown = null;

        foreach (Town town in towns) // If the hometown's name is in the list of towns currently in the game, sets flavor text intro for town.
        {
            if (town.Name.Equals(homeTownName))
            {
                homeTown = town;
                break;
            }
        }

        if (homeTown == null) // If the hometown is not found in the list of towns, it now exists but no one has heard of it.
        {
            homeTown = new Town(homeTownName, $"{player.Name}'s hometown.", "Never heard o' there before, but alright then.");
        }

        player.HomeTown = homeTown;

        WriteText($"\n{player.HomeTown.Intro}"); // Intro for entered town is displayed.

        WriteText($"\n{player.Name} of {player.HomeTown.Name}. That has a nice ring to it, doesn't it? Now, are ye a lass or lad?");

        player.Gender = ValidateAndGetInput().ToUpper(); // Checks if null. If null then prompts for another value.

        WriteText("\nAlright. Let's get this adventure started.\n\nPress any key to continue...");

        Console.ReadKey(true);
    }

    public static void WriteText(string input) // Used for "typing" effect on RPG prompts. Takes type string.
    {
        foreach (char ch in input)
        {
            Console.Write(ch);
            Thread.Sleep(0);
        }
        Console.Write('\n');
    }

    public static void PlayerAction(string? actionAndItem, Character player) // Character actions.
    {
        string action;
        string target;

        actionAndItem = actionAndItem.ToUpper();

        if (actionAndItem.Contains(' ')) // If there is a space in the entry, splits into two strings.
        {
            string[] command = actionAndItem.Split(' ');
            action = command[0];
            target = command[1];
        }
        else // If there is no space, make action the entry.
        {
            action = actionAndItem;
            target = "";
        }

        if (!playerActions.Contains(action)) // If action is not found, the game doesn't understand what is being said.
        {
            Console.Write("Ye make no sense.\n");

            return;
        }

        if (action.Equals(grabAction)) // Character grabs an item.
        {
            HandleGrab(player, target);
        }
        else if (action.Equals(inventoryAction))
        {
            HandleInventory(player);
        }
        else if (action.Equals(moveAction)) // Character moves.
        {
            // HandleMove(player, target);
        }
        else if (action.Equals(helpAction)) // Current commands with descriptions.
        {
            HandleHelp();
        }
        else if (action.Equals(clearAction))
        {
            Console.Clear();

            WriteText("The screen has been cleared for ye.");
        }
    }

    private static void HandleGrab(Character player, string targetItemName) // Logic for determining what was grabbed.
    {
        Item? itemToAdd = null;

        foreach (Item item in itemList) // If the item name is equal to entered target, add the item to inventory.
        {
            if (item.Name.Equals(targetItemName))
            {
                itemToAdd = item;
                break;
            }
        }

        if (itemToAdd == null) // If item does not exist, the game doesn't know what to grab.
        {
            Console.Write("Grab what, the air?\n");
        }
        else
        {
            // Add item

            if (!player.Inventory.Contains(itemToAdd)) // What happens when the item is added to inventory?
            {
                Console.Write($"You pick up the {itemToAdd.Name}.\n");
                player.Inventory.Add(itemToAdd);

                if (itemToAdd.Attack > 0) // Adds the picked up item's attack to current stats.
                {
                    Console.Write($"It increases your attack by {itemToAdd.Attack}!\n");
                    Console.Write($"Current attack: {player.Attack}\n");
                }
                if (itemToAdd.Defense > 0) // Adds the picked up item's defense to current stats.
                {
                    Console.Write($"It increases your defense by {itemToAdd.Defense}!\n");
                    Console.Write($"Current defense: {player.Defense}\n");
                }
            }
            else
            {
                Console.Write("Ye may have already picked that up.\n"); // The item is already in the character's inventory.
            }
        }
    }

    public static void HandleInventory(Character player)
    {
        if (player.Inventory == null || player.Inventory.Count < 1)
        {
            Console.Write("You have nothing in your inventory.\n");
        }

        foreach (Item? item in player.Inventory)
        {
            if (item.Attack > 0 && item.Defense == 0)
            {
                Console.Write($"{item.Name} - This has an attack of {item.Attack}.\n");
            }
            else if (item.Defense > 0 && item.Attack == 0)
            {
                Console.Write($"{item.Name} - This has a defense of {item.Defense}.\n");
            }
            else if (item.Attack > 0 && item.Defense > 0)
            {
                Console.Write($"{item.Name} - This has an attack of {item.Attack} and a defense of {item.Defense}.");
            }
            else if (item.Attack == 0 && item.Defense == 0)
            {
                Console.Write($"{item.Name} - This is just a {item.Name}. It's nothing special.\n");
            }
        }
    }

    //public static void HandleMove(Character player, string targetDestinationName) // Where is the character moving to?
    //{

    //}

    public static void HandleHelp() // The current character needs help. What do the commands do?
    {
        foreach (string playerAction in playerActions)
        {
            if (playerAction == grabAction)
            {
                Console.Write($"{grabAction} - Grab something in the same area as the player.\n");
            }
            else if (playerAction == inventoryAction)
            {
                Console.Write($"{inventoryAction} - Gives a brief description of the player's inventory.\n");
            }
            else if (playerAction == moveAction)
            {
                Console.Write($"{moveAction} - Move to the specified area. !NOT YET WORKING!\n");
            }
            else if (playerAction == helpAction)
            {
                Console.Write($"{helpAction} - See list of commands and what they each do.\n");
            }
            else if (playerAction == clearAction)
            {
                Console.Write($"{clearAction} - Clear the screen.\n");
            }
        }
    }

    public static string? ValidateAndGetInput() // Prompts if field is null, numeric, or not between 3-15.
    {
        bool inputIsNull, inputIsNumeric = false, inputIsCorrectLength = true;
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
        if (String.IsNullOrWhiteSpace(input))
        {
            Console.Write("No one can read minds. Say what ye mean.\n");
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
            if (!Char.IsLetter(ch) && !Char.IsWhiteSpace(ch))
            {
                Console.Write("No one asked for math. What do ye mean?\n");
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
            Console.Write($"Aye, slow down there! Ye answer must be {minimumInputLength}-{maximumInputLength} characters long.\n");
            return false;
        }
        else
        {
            return true;
        }
    }
}