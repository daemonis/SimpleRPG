namespace SimpleRPG;

class Program
{
    private readonly static World meridia = new();

    private static readonly Town steelSwamp = new("STEELSWAMP", null, 0, "Ah, rainy ol' STEELSWAMP. creepy place, that is. There be a strange inn there.");
    private static readonly Town ironHold = new("IRONHOLD", null, 1, "Ah, busy ol' IRONHOLD. Scary place, that is. They make weapons there.");
    private static readonly Town meadowLand = new("MEADOWLAND", null, 2, "Ah, peaceful ol' MEADOWLAND. Relaxing place, that is. They sell medicinal herbs there.");
    private static readonly Town forestView = new("FORESTVIEW", null, 3, "Ah, quiet ol' FORESTVIEW. Interesting place, that is. They make nice bows there.");
    private static readonly Town groveRest = new("GROVEREST", null, 4, "Ah, good ol' GROVEREST. Historical place, that is. The first Holy Church was built there.");

    private readonly static List<Town> towns = new() { steelSwamp, ironHold, meadowLand, forestView, groveRest };

    private static readonly Building inn = new("INN", 1);

    private static readonly List<Building> buildings = new() { inn };

    private static readonly Floor innLoft = new(2);
    private static readonly Floor innCommons = new(1);
    private static readonly Floor innStables = new(0);

    private static readonly List<Floor> floors = new() { innLoft, innCommons, innStables };

    private static readonly Room bedRoom = new("BEDROOM", 3, "You can see your bed and a nightstand in here. The bed has an uncomfortable blanket on top.");
    private static readonly Room bathRoom = new("BATHROOM", 2, "There is a small sink and a toilet in here. It isn't that spacious.");
    private static readonly Room hallWay = new("HALLWAY", 1, "A narrow corridor with doors lining each side. You can see stairs at the end of the hallway.");
    private static readonly Room bar = new("BAR", 2, "There are few patrons here. There are probably much better places to be. You see the barkeep behind the counter and nod to them.");
    private static readonly Room den = new("DEN", 1, "There are two small loveseats in this area. On the ground is a hideous rug with mud pretty much woven into it. In the corner of the room are some stairs.");
    private static readonly Room stables = new("STABLES", 1, "There are one, maybe two horses here. It doesn't smell too nice. Behind you are some stairs.");
    private static readonly Room up = new("UP", 0, $"You move up 1 floor.");
    private static readonly Room down = new("DOWN", 0, $"You move down 1 floor.");

    private static readonly List<Room> rooms = new() { bedRoom, bathRoom, hallWay, bar, den, stables };

    private static readonly Item sword = new("SWORD", 1, 0, 25);
    private static readonly Item bag = new("BAG", 0, 0, 0);
    private static readonly Item armor = new("ARMOR", 0, 2, 50);
    private static readonly Item shield = new("SHIELD", 0, 1, 25);
    private static readonly Item toothBrush = new("TOOTHBRUSH", 0, 0, 5);
    private static readonly Item lamp = new("LAMP", 0, 0, 10);

    private static readonly List<Item> itemList = new() { sword, bag, armor, shield, toothBrush, lamp };

    private static readonly string grabAction = "GRAB";
    private static readonly string dropAction = "DROP";
    private static readonly string inventoryAction = "INVENTORY";
    private static readonly string lookAction = "LOOK";
    private static readonly string moveAction = "MOVETO";
    private static readonly string helpAction = "HELP";
    private static readonly string clearAction = "CLEAR";

    private static readonly List<string> playerActions = new() { grabAction, dropAction, inventoryAction, lookAction, moveAction, helpAction, clearAction };

    private static int worldNum, townNum, buildingNum, floorNum, roomNum;

    public static void Main()
    {
        // Intro

        IntroToMeridia();

        BuildAMap(); // Makes an Inn. That's it at the moment.

        Console.Clear();

        // Collect character information.

        Character player = new(); // Create new player character.

        player.IsAlive = true;
        player.Inventory = new List<Item>();
        player.Location = new int[5] { worldNum = meridia.WorldValue, townNum = steelSwamp.TownValue, buildingNum = inn.BuildingValue, floorNum = innLoft.FloorValue, roomNum = bedRoom.RoomValue };

        CollectCharacterInformation(player);

        Console.Clear();

        // Adventure Start. (WIP)

        WriteText($"It is a dark and stormy night in the town of {steelSwamp.Name}. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you've decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but is bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your {sword.Name}. Your {bag.Name} rests atop the nightstand. There is a {bathRoom.Name} and a {hallWay.Name} attached to the bedroom.\n\nWhat will you do?");

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
        WriteText($"Welcome, adventurer, to the world of {meridia.Name}.\n\nPress any key to start your adventure...");

        Console.ReadKey(true);
    }

    public static void BuildAMap() // The layout of the worldmap.
    {
        meridia.Layout = towns;

        steelSwamp.Layout = new List<Building>(); // The layout of the town STEELSWAMP.

        steelSwamp.Layout.Add(inn);
        {
            inn.Layout = new List<Floor>(); // The layout of the building INN.

            inn.Layout.Add(innLoft);
            {
                innLoft.Layout = new List<Room>(); // Third floor.
                {
                    innLoft.Layout.Add(bedRoom); // First room of the third flood of the inn. What items are there?

                    bedRoom.Layout = new List<Item>();
                    {
                        bedRoom.Layout.Add(sword);
                        bedRoom.Layout.Add(bag);
                    }

                    innLoft.Layout.Add(bathRoom); // Second room of the third floor of the inn. What items are there?

                    bathRoom.Layout = new List<Item>();
                    {
                        bathRoom.Layout.Add(toothBrush);
                    }

                    innLoft.Layout.Add(hallWay);

                    hallWay.Layout = new List<Item>(); // Third room of the third flood of the inn. What items are there?
                    {
                        hallWay.Layout.Add(lamp);
                    }

                    innLoft.Layout.Add(down);
                }

                inn.Layout.Add(innCommons); // Second floor.

                innCommons.Layout = new List<Room>();
                {
                    innCommons.Layout.Add(bar); // First room of the second flood of the inn. What items are there?

                    bar.Layout = new List<Item>();

                    innCommons.Layout.Add(den); // Second room of the second flood of the inn. What items are there?

                    den.Layout = new List<Item>();

                    innCommons.Layout.Add(up);
                    innCommons.Layout.Add(down);
                }

                inn.Layout.Add(innStables); // First floor. Can go outside from here.

                innStables.Layout = new List<Room>();
                {
                    innStables.Layout.Add(stables); // First room of the first flood of the inn. What items are there?

                    stables.Layout = new List<Item>();

                    innStables.Layout.Add(up);
                }
            }
        }
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
        else if (action.Equals(dropAction))
        {
            HandleDrop(player, target);
        }
        else if (action.Equals(inventoryAction)) // Character's current inventory.
        {
            HandleInventory(player);
        }
        else if (action.Equals(moveAction)) // Character moves.
        {
            HandleMove(player, target);
        }
        else if (action.Equals(helpAction)) // Current commands with descriptions.
        {
            HandleHelp();
        }
        else if (action.Equals(clearAction)) // Clears the screen.
        {
            Console.Clear();

            WriteText("The screen has been cleared for ye.");
        }
    }

    private static void HandleDrop(Character player, string targetItemName) // Logic for determining what was grabbed.
    {
        Item? itemToRemove = null;
        int stairLocation = 1;

        foreach (Town town in meridia.Layout)
        {
            if (player.Location[1].Equals(town.TownValue))
            {
                foreach (Building building in town.Layout)
                {
                    if (player.Location[2].Equals(building.BuildingValue))
                    {
                        foreach (Floor floor in building.Layout)
                        {
                            if (player.Location[3].Equals(floor.FloorValue))
                            {
                                foreach (Room room in floor.Layout) // If the room name is equal to entered target, move there.
                                {
                                    if (player.Location[4].Equals(room.RoomValue) && player.Location[4] != 0)
                                    {
                                        foreach (Item item in player.Inventory) // If the item name is equal to entered target, add the item to inventory.
                                        {
                                            if (item.Name.Equals(targetItemName))
                                            {
                                                itemToRemove = item;
                                                break;
                                            }
                                        }

                                        if (itemToRemove == null) // If item does not exist, the game doesn't know what to grab.
                                        {
                                            Console.Write("Drop what, ye trousers?\n");

                                            return;
                                        }
                                        else
                                        {
                                            // Add item

                                            if (player.Inventory.Contains(itemToRemove)) // What happens when the item is added to inventory?
                                            {
                                                Console.Write($"You drop the {itemToRemove.Name}.\n");

                                                player.Inventory.Remove(itemToRemove);

                                                room.Layout.Add(itemToRemove);

                                                if (itemToRemove.Attack > 0) // Adds the picked up item's attack to current stats.
                                                {
                                                    Console.Write($"Your attack decreases by {itemToRemove.Attack}!\n");
                                                    Console.Write($"Current attack: {player.Attack}\n");
                                                }
                                                if (itemToRemove.Defense > 0) // Adds the picked up item's defense to current stats.
                                                {
                                                    Console.Write($"Your defense decreases by {itemToRemove.Defense}!\n");
                                                    Console.Write($"Current defense: {player.Defense}\n");
                                                }

                                                return;
                                            }
                                            else if (!player.Inventory.Contains(itemToRemove))
                                            {
                                                Console.Write("Ye don't have one o' those.\n"); // The item is already in the character's inventory.

                                                return;
                                            }
                                        }
                                    }
                                    else if (player.Location[4] < stairLocation)
                                    {
                                        Console.Write("Ye can't drop that here.\n");

                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private static void HandleMove(Character player, string target) // Logic for determining movement.
    {
        Room? targetRoom = null;
        int stairLocation = 1;

        foreach (Town town in meridia.Layout)
        {
            if (player.Location[1].Equals(town.TownValue))
            {
                foreach (Building building in town.Layout)
                {
                    if (player.Location[2].Equals(building.BuildingValue))
                    {
                        foreach (Floor floor in building.Layout)
                        {
                            if (player.Location[3].Equals(floor.FloorValue))
                            {
                                foreach (Room room in floor.Layout) // If the room name is equal to entered target, move there.
                                {
                                    if (target.Equals(room.Name)) // If room exists and character can move there, set current room.
                                    {
                                        targetRoom = room;

                                        if (room.Layout == null || room.Layout.Count < 0)
                                        {
                                            targetRoom.Layout = null;
                                        }
                                        else
                                        {
                                            targetRoom.Layout = room.Layout;
                                        }

                                        break;
                                    }
                                }

                                if (targetRoom == null) // If room doesn't exist, you can't go there.
                                {
                                    Console.Write("Where do ye want to go? Ye can currently move to:\n");

                                    foreach (Room room in floor.Layout)
                                    {
                                        if (player.Location[4] < 2)
                                        {
                                            Console.Write($"{room.Name}\n");
                                        }
                                        else if (room.RoomValue != 0)
                                        {
                                            Console.Write($"{room.Name}\n");
                                        }
                                    }

                                    return;
                                }
                                else if (targetRoom.Name.Equals(up.Name) && player.Location[4] <= stairLocation)
                                {
                                    player.Location[3] += 1;
                                    player.Location[4] = targetRoom.RoomValue;

                                    WriteText(targetRoom.Description);

                                    return;
                                }
                                else if (targetRoom.Name.Equals(down.Name) && player.Location[4] <= stairLocation)
                                {
                                    player.Location[3] -= 1;
                                    player.Location[4] = targetRoom.RoomValue;

                                    WriteText(targetRoom.Description);

                                    return;
                                }
                                else if (player.Location[4] > stairLocation && targetRoom.Name.Equals(up.Name) || player.Location[4] > stairLocation && targetRoom.Name.Equals(down.Name))
                                {
                                    Console.Write("There be no stairs here.\n");

                                    return;
                                }
                                else if (player.Location[4] < stairLocation && targetRoom.RoomValue > stairLocation)
                                {
                                    Console.Write("Ye can't see that room from here.\n");

                                    return;
                                }
                                else if (targetRoom.RoomValue == player.Location[4]) // If you are already in the room, you are already there.
                                {
                                    Console.Write("Ye are already there.\n");

                                    return;
                                }

                                Console.Write($"You have moved to the {targetRoom.Name}.\n"); // You move, description of room shows.
                                WriteText(targetRoom.Description);

                                //if (targetRoom.Layout == null || targetRoom.Layout.Count < 0)
                                //{
                                //    Console.Write("Ye see nothing to pick up.\n");
                                //}
                                //else
                                //{
                                foreach (Item item in targetRoom.Layout) // What items are in the room?
                                {
                                    Console.Write($"You can see a {item.Name}.\n");
                                }
                                //}

                                player.Location[4] = targetRoom.RoomValue;
                            }
                        }
                    }
                }
            }
        }
    }

    private static void HandleGrab(Character player, string targetItemName) // Logic for determining what was grabbed.
    {
        Item? itemToAdd = null;

        foreach (Town town in meridia.Layout)
        {
            if (player.Location[1].Equals(town.TownValue))
            {
                foreach (Building building in town.Layout)
                {
                    if (player.Location[2].Equals(building.BuildingValue))
                    {
                        foreach (Floor floor in building.Layout)
                        {
                            if (player.Location[3].Equals(floor.FloorValue))
                            {
                                foreach (Room room in floor.Layout) // If the room name is equal to entered target, move there.
                                {
                                    if (player.Location[4].Equals(room.RoomValue))
                                    {
                                        foreach (Item item in room.Layout) // If the item name is equal to entered target, add the item to inventory.
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

                                            return;
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

                                                room.Layout.Remove(itemToAdd);

                                                return;
                                            }
                                            else
                                            {
                                                Console.Write("Ye may have already picked that up.\n"); // The item is already in the character's inventory.

                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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

    public static void HandleHelp() // The current character needs help. What do the commands do?
    {
        foreach (string playerAction in playerActions)
        {
            if (playerAction == grabAction)
            {
                Console.Write($"{grabAction} - Grab something in the room and put it into your inventory.\n");
            }
            else if (playerAction == dropAction)
            {
                Console.Write($"{dropAction} - Drop something from your inventory into the current room.\n");
            }
            else if (playerAction == inventoryAction)
            {
                Console.Write($"{inventoryAction} - Gives a brief description of the player's inventory.\n");
            }
            else if (playerAction == moveAction)
            {
                Console.Write($"{moveAction} - Move to the specified location.\n");
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
        int maximumInputLength = 25;

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