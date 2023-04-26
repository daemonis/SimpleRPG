namespace SimpleRPG;

class Program
{
    private readonly static World meridia = new();

    private static readonly Town steelSwamp = new("STEELSWAMP", "It seems like it will never stop raining... There is an INN here.", 0, "Ah, rainy ol' STEELSWAMP. creepy place, that is. There be a strange inn there.");
    private static readonly Town ironHold = new("IRONHOLD", "There isn't a cloud in the sky. The sun is intense.", 1, "Ah, busy ol' IRONHOLD. Scary place, that is. They make weapons there.");
    private static readonly Town meadowLand = new("MEADOWLAND", "The weather is rather comfortable. The air smells of flowers.", 2, "Ah, peaceful ol' MEADOWLAND. Relaxing place, that is. They sell medicinal herbs there.");
    private static readonly Town forestView = new("FORESTVIEW", "It seems impossible to see the sky through the trees.", 3, "Ah, quiet ol' FORESTVIEW. Interesting place, that is. They make nice bows there.");
    private static readonly Town groveRest = new("GROVEREST", "Clouds block the sun from the sky...", 4, "Ah, good ol' GROVEREST. Historical place, that is. The first Holy CHURCH is built there.");

    private readonly static List<Town> towns = new() { steelSwamp, ironHold, meadowLand, forestView, groveRest };

    private static readonly Building inn = new("INN", 1, "You enter the STABLES. The main part of the building rests UP off the ground. There is a way UP here.");

    private static readonly Building armory = new("ARMORY", 1, "You enter the SHOWROOM. Inside the modest building are all types of swords and armor. There is a way OUT here.");

    private static readonly Building outSideSwamp = new("OUT", 0, "Immediately it feels as if you are wading through water. You wish your boots were taller.");
    private static readonly Building outSideIron = new("OUT", 0, "You look around. Everything living is hiding under the limited brush. The air burns your nostrils.");
    private static readonly Building outSideMeadow = new("OUT", 0, "The scent of flowers eventually fades the longer you endure it.");
    private static readonly Building outSideForest = new("OUT", 0, "The scent of sap is pleasant, and the shade is nice and cool. You wouldn't mind living here.");
    private static readonly Building outSideGrove = new("OUT", 0, "If you did see anyone, they would quickly look the other way. This town didn't seem very friendly.");

    //private static readonly List<Building> buildings = new() { inn, outSideSwamp, outSideIron, outSideMeadow, outSideForest, outSideGrove };

    private static readonly Floor innLoft = new("LOFT", 2);
    private static readonly Floor innCommons = new("COMMONS", 1);
    private static readonly Floor innStables = new("STABLES", 0);

    private static readonly Floor armoryFloor = new("ARMORYFLOOR", 0);

    private static readonly Floor groundSwamp = new("GROUNDSWAMP", 0);
    private static readonly Floor groundIron = new("GROUNDIRON", 0);
    private static readonly Floor groundMeadow = new("GROUNDMEADOW", 0);
    private static readonly Floor groundForest = new("GROUNDFOREST", 0);
    private static readonly Floor groundGrove = new("GROUNDGROVE", 0);

    //private static readonly List<Floor> floors = new() { innLoft, innCommons, innStables, groundSwamp, groundIron, groundMeadow, groundForest, groundGrove };

    private static readonly Room bedRoom = new("BEDROOM", 3, "You can see your bed and a nightstand in here. The bed has an uncomfortable blanket on top. In the corner is an armor rack. You can see your BATHROOM, and you know the HALLWAY is outside your BEDROOM.");
    private static readonly Room bathRoom = new("BATHROOM", 2, "There is a small sink and a toilet in here. It isn't that spacious. You can see your BEDROOM through the door.");
    private static readonly Room hallWay = new("HALLWAY", 1, "There is a narrow corridor with doors lining each side. You can see a way DOWN at the end of the hallway. Your BEDROOM was the furthest door from the way DOWN.");

    private static readonly Room bar = new("BAR", 2, "There are few patrons here. There are probably much better places to be. You think to yourself a drink might be nice before you go. You can see the DEN from here.");
    private static readonly Room den = new("DEN", 1, "There are two small loveseats in this area. On the ground is a hideous rug with mud pretty much woven into it. In the corner of the room are a way UP and a way DOWN. You can see the BAR from here.");

    private static readonly Room stables = new("STABLES", 1, "There are one, maybe two horses here. It doesn't smell too nice. There is a way UP and there is a way OUT here.");

    private static readonly Room showRoom = new("SHOWROOM", 1, "Around the room you can see various flails and swords that are for sale by the owners of the business. Maybe you can find some nice equipment here. There is a way OUT here.");

    private static readonly Room up = new("UP", 0, "You move up 1 floor. Take a LOOK around.");
    private static readonly Room down = new("DOWN", 0, "You move down 1 floor. Take a LOOK around.");

    private static readonly Room swamp = new("WETLANDS", 1, $"It is cold and rainy out. You can hear the terrible sound of treebranches scratching against eachother in the wind. There is an {inn.Name} here. You can see {ironHold.Name} off in the distance, whose lands are barren and dry.");
    private static readonly Room barrens = new("BARRENS", 1, $"The landscape is a scorching dry heat. The patches of dirt littering the area around you contain vibrant reds from how much iron it contains. There is an {armory.Name} here. You can see {steelSwamp.Name} from where you came from, and {meadowLand.Name} off in the distance, whose lands are lush and green.");
    private static readonly Room meadow = new("GRASSLANDS", 1, $"The landscape is a lucious green meadow. All around you can see healthy trees and different types of flowers. You can see {ironHold.Name} from where you came, and {forestView.Name} off in the distance, whose lands are filled with dense trees.");
    private static readonly Room forest = new("WOODLANDS", 1, $"The landscape is a dense forest. You can barely see anywhere through all the trees. The calls of various birds could be heard. You can see {meadowLand.Name} from where you came, and {groveRest.Name} off in the distance, where the first Holy CHURCH resides.");
    private static readonly Room grove = new("SCRUBLANDS", 1, $"The landscape is an open field. You come up upon a town as you enter the quiet area. There didn't seem to be many people around. At the center a large CHURCH stands. You can see {forestView.Name} from where you came.");

    //private static readonly List<Room> rooms = new() { bedRoom, bathRoom, hallWay, bar, den, stables, swamp, barrens, meadow, forest, grove };

    private static readonly Item sword = new("SWORD", 1, 0, 5, 25);
    private static readonly Item greatSword = new("GREATSWORD", 2, 0, 6, 45);
    private static readonly Item flail = new("FLAIL", 1, 0, 5, 25);
    private static readonly Item hammer = new("HAMMER", 2, 0, 6, 45);
    private static readonly Item bag = new("BAG", 0, 0, 9, 0);
    private static readonly Item armor = new("ARMOR", 0, 2, 1, 50);
    private static readonly Item helmet = new("HELMET", 0, 1, 0, 15);
    private static readonly Item boots = new("BOOTS", 0, 1, 4, 15);
    private static readonly Item shield = new("SHIELD", 0, 1, 5, 25);
    private static readonly Item toothBrush = new("TOOTHBRUSH", 0, 0, 7, 0);
    private static readonly Item lamp = new("LAMP", 0, 0, 7, 10);
    private static readonly Item cup = new("CUP", 0, 0, 0, 0);
    private static readonly Item wine = new("WINE", 0, 0, 8, 25);
    private static readonly Item beer = new("BEER", 0, 0, 8, 10);
    private static readonly Item mead = new("MEAD", 0, 0, 8, 15);

    //private static readonly List<Item> itemList = new() { sword, bag, armor, shield, toothBrush, lamp, cup, wine, beer, mead, greatSword, flail, hammer, helmet, boots };

    private static readonly NPC shopKeep = new("SHOPKEEP", "They are wiping down the counter and tending to the person sitting at the bar.");
    private static readonly NPC apothecary = new("APOTHECARY", "They are measuring various powders and salves to be mixed.");
    private static readonly NPC weaponSmith = new("WEAPONSMITH", "They are inspecting the various blades they have on sale.");
    private static readonly NPC armorSmith = new("ARMORSMITH", "They are polishing what appears to be a pauldron.");

    private static readonly Monster ghost = new("GHOST");

    private static readonly string grabAction = "GRAB";
    private static readonly string dropAction = "DROP";
    private static readonly string equipAction = "EQUIP";
    private static readonly string unequipAction = "UNEQUIP";
    private static readonly string inventoryAction = "INVENTORY";
    private static readonly string equipmentAction = "EQUIPMENT";
    private static readonly string lookAction = "LOOK";
    private static readonly string talkAction = "TALKTO";
    private static readonly string moveAction = "MOVETO";
    private static readonly string helpAction = "HELP";
    private static readonly string clearAction = "CLEAR";

    private static readonly List<string> playerActions = new() { grabAction, dropAction, equipAction, unequipAction, inventoryAction, equipmentAction, lookAction, talkAction, moveAction, helpAction, clearAction };

    public static void Main()  // The game. (You lost...)
    {
        // Intro

        IntroToMeridia();

        BuildAMap(); // Builds the world as it is currently.

        Console.Clear();

        // Collect character information.

        Character player = new() // Create new player character. Set player's location. Set inventory and equipment to empty.
        {
            IsAlive = true,
            Inventory = new List<Item>(),
            Equipment = new List<Item>(),
            Location = new int[5] { meridia.WorldValue, steelSwamp.TownValue, inn.BuildingValue, innLoft.FloorValue, bedRoom.RoomValue }
        };

        CollectCharacterInformation(player);

        Console.Clear();

        // Adventure Start. (WIP)

        WriteText($"It is a dark and stormy night in the town of {steelSwamp.Name}. You can hear the sound of the rain tapping on the roof of the inn and the gentle flow of water coursing through the surrounding wetlands.\n\nThe inn you've decided to take refuge in is not the best, but it beats being out in the rain. The innkeep also gave you a great deal on the room you are staying in.\n\nYou are currently laying in bed. The blankets are made from a rough wool that isn't too comfortable, but is bound to keep any adventurer warm. You have a nightstand next to you, agaist which you've leaned your {sword.Name}. In the corner of the room was an armor rack with some {armor.Name}. There is a {bathRoom.Name} and a {hallWay.Name} attached to the bedroom.\n\nWhat will you do?");

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
        {
            steelSwamp.Layout.Add(inn);

            inn.Layout = new List<Floor>(); // The layout of the building INN.
            {
                inn.Layout.Add(innLoft);

                innLoft.Layout = new List<Room>(); // Third floor.
                {
                    innLoft.Layout.Add(bedRoom); // First room of the third flood of the inn. What items are there?

                    bedRoom.Layout = new List<Item>();
                    {
                        bedRoom.Layout.Add(sword);
                        bedRoom.Layout.Add(armor);
                    }

                    bedRoom.Persons = new List<NPC>();

                    innLoft.Layout.Add(bathRoom); // Second room of the third floor of the inn. What items are there?

                    bathRoom.Layout = new List<Item>();
                    {
                        bathRoom.Layout.Add(toothBrush);
                        bathRoom.Layout.Add(cup);
                    }

                    bathRoom.Persons = new List<NPC>();

                    innLoft.Layout.Add(hallWay);

                    hallWay.Layout = new List<Item>(); // Third room of the third flood of the inn. What items are there?
                    {
                        hallWay.Layout.Add(lamp);
                    }

                    hallWay.Persons = new List<NPC>();

                    innLoft.Layout.Add(down);
                }

                inn.Layout.Add(innCommons); // Second floor.

                innCommons.Layout = new List<Room>();
                {
                    innCommons.Layout.Add(bar); // First room of the second flood of the inn. What items are there?

                    bar.Layout = new List<Item>();
                    {
                        bar.Layout.Add(cup);
                        bar.Layout.Add(cup);
                    }

                    bar.Persons = new List<NPC>();
                    {
                        bar.Persons.Add(shopKeep);

                        shopKeep.Inventory = new List<Item>();
                        {
                            shopKeep.Inventory.Add(wine);
                            shopKeep.Inventory.Add(beer);
                            shopKeep.Inventory.Add(mead);
                        }
                    }

                    innCommons.Layout.Add(den); // Second room of the second flood of the inn. What items are there?

                    den.Layout = new List<Item>();

                    den.Persons = new List<NPC>();

                    innCommons.Layout.Add(up);
                    innCommons.Layout.Add(down);
                }

                inn.Layout.Add(innStables); // First floor. Can go outside from here.

                innStables.Layout = new List<Room>();
                {
                    innStables.Layout.Add(stables); // First room of the first floor of the inn. What items are there?

                    stables.Layout = new List<Item>();

                    stables.Persons = new List<NPC>();

                    innStables.Layout.Add(up);
                }
            }

            steelSwamp.Layout.Add(outSideSwamp);

            outSideSwamp.Layout = new List<Floor>();
            {
                outSideSwamp.Layout.Add(groundSwamp);

                groundSwamp.Layout = new List<Room>();
                {
                    groundSwamp.Layout.Add(swamp);

                    swamp.Layout = new List<Item>();

                    swamp.Persons = new List<NPC>();
                }
            }
        }

        ironHold.Layout = new List<Building>();
        {
            ironHold.Layout.Add(armory);

            armory.Layout = new List<Floor>();
            {
                armory.Layout.Add(armoryFloor);

                armoryFloor.Layout = new List<Room>();
                {
                    armoryFloor.Layout.Add(showRoom);

                    showRoom.Layout = new List<Item>();

                    showRoom.Persons = new List<NPC>();
                    {
                        showRoom.Persons.Add(armorSmith);

                        armorSmith.Inventory = new List<Item>();
                        {
                            armorSmith.Inventory.Add(helmet);
                            armorSmith.Inventory.Add(boots);
                            armorSmith.Inventory.Add(shield);
                            armorSmith.Inventory.Add(armor);
                        }

                        showRoom.Persons.Add(weaponSmith);

                        weaponSmith.Inventory = new List<Item>();
                        {
                            weaponSmith.Inventory.Add(greatSword);
                            weaponSmith.Inventory.Add(flail);
                            weaponSmith.Inventory.Add(hammer);
                        }
                    }
                }
            }

            ironHold.Layout.Add(outSideIron);

            outSideIron.Layout = new List<Floor>();
            {
                outSideIron.Layout.Add(groundIron);

                groundIron.Layout = new List<Room>();
                {
                    groundIron.Layout.Add(barrens);

                    barrens.Layout = new List<Item>();

                    barrens.Persons = new List<NPC>();
                }
            }
        }

        meadowLand.Layout = new List<Building>();
        {
            meadowLand.Layout.Add(outSideMeadow);

            outSideMeadow.Layout = new List<Floor>();
            {
                outSideMeadow.Layout.Add(groundMeadow);

                groundMeadow.Layout = new List<Room>();
                {
                    groundMeadow.Layout.Add(meadow);

                    meadow.Layout = new List<Item>();

                    meadow.Persons = new List<NPC>();
                }
            }
        }

        forestView.Layout = new List<Building>();
        {
            forestView.Layout.Add(outSideForest);

            outSideForest.Layout = new List<Floor>();
            {
                outSideForest.Layout.Add(groundForest);

                groundForest.Layout = new List<Room>();
                {
                    groundForest.Layout.Add(forest);

                    forest.Layout = new List<Item>();

                    forest.Persons = new List<NPC>();
                }
            }
        }

        groveRest.Layout = new List<Building>();
        {
            groveRest.Layout.Add(outSideGrove);

            outSideGrove.Layout = new List<Floor>();
            {
                outSideGrove.Layout.Add(groundGrove);

                groundGrove.Layout = new List<Room>();
                {
                    groundGrove.Layout.Add(grove);

                    grove.Layout = new List<Item>();

                    grove.Persons = new List<NPC>();
                }
            }
        }
    }

    public static void CollectCharacterInformation(Character player) // Collects character information.
    {
        WriteText("What be your name, traveler?");

        player.Name = ValidateAndGetInput().ToUpper(); // Checks if null. If null then prompts to enter another value.

        WriteText($"\nGreetings, {player.Name}. From where do ye hail?");

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

        WriteText($"\n{player.Name} of {player.HomeTown.Name}... That has a nice ring to it, doesn't it?");

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

    public static void PlayerAction(string? actionAndTarget, Character player) // Character actions.
    {
        string action;
        string target;

        actionAndTarget = actionAndTarget.ToUpper();

        if (actionAndTarget.Contains(' ')) // If there is a space in the entry, splits into two strings.
        {
            string[] command = actionAndTarget.Split(' ');
            action = command[0];
            target = command[1];
        }
        else // If there is no space, make action the entry.
        {
            action = actionAndTarget;
            target = "";
        }

        if (!playerActions.Contains(action)) // If action is not found, the game doesn't understand what is being said.
        {
            Console.Write($"Ye make no sense. Type {helpAction} for help.\n");

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
        else if (action.Equals(equipAction))
        {
            HandleEquip(player, target);
        }
        else if (action.Equals(unequipAction))
        {
            HandleUnequip(player, target);
        }
        else if (action.Equals(inventoryAction)) // Character's current inventory.
        {
            HandleInventory(player);
        }
        else if (action.Equals(equipmentAction)) // Character's current inventory.
        {
            HandleEquipment(player);
        }
        else if (action.Equals(lookAction))
        {
            HandleLook(player);
        }
        else if (action.Equals(talkAction))
        {
            HandleTalk(player, target);
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

    private static void HandleUnequip(Character player, string target) // Have the player unequip a currently equipped item.
    {
        Item targetItem = null;

        foreach (Item item in player.Equipment)
        {
            if (item.Name == target)
            {
                targetItem = item;

                break;
            }
        }

        switch (targetItem)
        {
            case null:
                Console.Write($"Ye not wearin' one o' those. Maybe ye should check your {equipmentAction}.\n");
                return;
            default:
                player.Equipment.Remove(targetItem);

                player.Inventory.Add(targetItem);

                Console.Write($"\nYou unequip the {targetItem}!\n");

                if (targetItem.Defense <= 0)
                {
                    Console.Write($"Your attack decreases by {targetItem.Attack}!\n");
                }
                else if (targetItem.Attack <= 0)
                {
                    Console.Write($"Your defense decreases by {targetItem.Defense}!\n");
                }
                else
                {
                    Console.Write($"Your attack decreases by {targetItem.Attack}!\n");
                    Console.Write($"Your defense decreases by {targetItem.Defense}!\n");
                }

                Console.Write($"Current attack: {player.Attack}\n");
                Console.Write($"Current defense: {player.Defense}\n");

                return;
        }
    }

    private static void HandleEquip(Character player, string target) // Have the player equip an item currently in their inventory.
    {
        Item targetItem = null;
        int oneHandedWeaponCount = 0;

        foreach (Item item in player.Inventory)
        {
            if (item.Name == target)
            {
                targetItem = item;

                break;
            }
        }

        switch (targetItem)
        {
            case null:
                Console.Write($"Ye don't have one o' those. Maybe ye should check your {inventoryAction}.\n");
                return;
            default:
                if (targetItem.Attack <= 0 && targetItem.Defense <= 0)
                {
                    Console.Write("That does nothing for ye.\n");

                    return;
                }
                else
                {
                    foreach (Item equippedItem in player.Equipment)
                    {
                        if (targetItem.Identifier.Equals(equippedItem.Identifier))
                        {
                            if (targetItem.Identifier.Equals(5))
                            {
                                oneHandedWeaponCount++;

                                if (oneHandedWeaponCount >= 2)
                                {
                                    Console.Write($"\nYe do not have enough hands.\n");

                                    return;
                                }
                            }
                            else
                            {
                                Console.Write($"\nYe cannot put on another o' those.\n");

                                return;
                            }
                        }
                        else if ((targetItem.Identifier.Equals(6) && equippedItem.Identifier.Equals(5)) || (targetItem.Identifier.Equals(5) && equippedItem.Identifier.Equals(6)))
                        {
                            Console.Write($"\nYe do not have enough hands.\n");

                            return;
                        }
                    }

                    if (targetItem.Attack > 0 || targetItem.Defense > 0)
                    {
                        player.Inventory.Remove(targetItem);

                        player.Equipment.Add(targetItem);

                        Console.Write($"\nYou equip the {targetItem}!\n");

                        if (targetItem.Defense <= 0)
                        {
                            Console.Write($"Your attack increases by {targetItem.Attack}!\n");
                        }
                        else if (targetItem.Attack <= 0)
                        {
                            Console.Write($"Your defense increases by {targetItem.Defense}!\n");
                        }
                        else
                        {
                            Console.Write($"Your attack increases by {targetItem.Attack}!\n");
                            Console.Write($"Your defense increases by {targetItem.Defense}!\n");
                        }

                        Console.Write($"Current attack: {player.Attack}\n");
                        Console.Write($"Current defense: {player.Defense}\n");
                    }

                    return;
                }
        }
    }

    private static void HandleTalk(Character player, string targetPersonName) // Have the player talk to someone in the area.
    {
        NPC targetPerson = null;
        Item targetItemToBuy = null;
        Item targetItemToSell = null;
        string itemChoiceToBuy = null;
        string itemChoiceToSell = null;

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
                                        foreach (NPC person in room.Persons)
                                        {
                                            if (person.Name.Equals(targetPersonName))
                                            {
                                                targetPerson = person;

                                                break;
                                            }
                                        }

                                        if (targetPerson == null)
                                        {
                                            Console.Write($"Ye see a ghost? Maybe ye should {lookAction} around.\n");

                                            return;
                                        }
                                        else if (targetPerson.Name.Equals("SHOPKEEP") || targetPerson.Name.Equals("APOTHECARY") || targetPerson.Name.Equals("WEAPONSMITH") || targetPerson.Name.Equals("ARMORSMITH"))
                                        {
                                            if (player.Inventory.Count < 1 && targetPerson.Inventory.Count < 1)
                                            {
                                                WriteText($"\nHope ye are having a good day, {player.Name}.");

                                                return;
                                            }
                                            else if (targetPerson.Inventory.Count > 0)
                                            {
                                                WriteText("\nWhat would ye like to buy? Or are you here to SELL? Here's what I have:");

                                                foreach (Item item in targetPerson.Inventory)
                                                {
                                                    Console.Write($"{item.Name} - {item.MoneyValue} coppers\n");
                                                }

                                                Console.Write($"Current coins: {player.WalletValue} coppers\n");

                                                itemChoiceToBuy = ValidateAndGetInput().ToUpper();

                                                if (itemChoiceToBuy.Equals("YES"))
                                                {
                                                    itemChoiceToBuy = "SELL";
                                                }

                                                foreach (Item item in targetPerson.Inventory)
                                                {
                                                    if (item.Name.Equals(itemChoiceToBuy))
                                                    {
                                                        targetItemToBuy = item;

                                                        break;
                                                    }
                                                }
                                            }

                                            if (targetPerson.Inventory.Count < 1 || itemChoiceToBuy.Equals("SELL"))
                                            {
                                                if (itemChoiceToBuy == null)
                                                {
                                                    WriteText("\nI got nothing left to buy... Are ye here to SELL something?");

                                                    itemChoiceToBuy = ValidateAndGetInput().ToUpper();
                                                }

                                                if (itemChoiceToBuy != "SELL" && itemChoiceToBuy != "YES" || itemChoiceToBuy.Equals("NO"))
                                                {
                                                    WriteText("\nI have to get back to work, then. Have a good day.");

                                                    return;
                                                }
                                                else if (itemChoiceToBuy.Equals("SELL") || itemChoiceToBuy.Equals("YES"))
                                                {
                                                    if (player.Inventory.Count < 1)
                                                    {
                                                        WriteText("\n...Ye good at jokes. Ye ain't even got anything to sell. Good day.");

                                                        return;
                                                    }

                                                    WriteText("\nIf ye have something interesting, I'll buy. Sell what?");

                                                    foreach (Item item in player.Inventory)
                                                    {
                                                        if (item.MoneyValue != 0)
                                                        {
                                                            Console.Write($"{item.Name} - {item.MoneyValue} coppers\n");
                                                        }
                                                    }

                                                    Console.Write($"Current coins: {player.WalletValue} coppers\n");

                                                    itemChoiceToSell = ValidateAndGetInput().ToUpper();

                                                    foreach (Item item in player.Inventory)
                                                    {
                                                        if (item.Name.Equals(itemChoiceToSell))
                                                        {
                                                            targetItemToSell = item;

                                                            break;
                                                        }
                                                    }

                                                    if (targetItemToSell == null)
                                                    {
                                                        WriteText("\nI have to get back to work, then. Have a good day.");

                                                        return;
                                                    }
                                                    else
                                                    {
                                                        WriteText($"\nHere is ye {targetItemToSell.MoneyValue} coppers. Now let me just...");

                                                        Console.Write($"\nYou give the {targetPerson.Name} the {targetItemToSell.Name}.\nThe {targetPerson.Name} gives you {targetItemToSell.MoneyValue} coppers.\n\nGood day.\n");

                                                        player.WalletValue = player.WalletValue + targetItemToSell.MoneyValue;

                                                        player.Inventory.Remove(targetItemToSell);

                                                        targetPerson.Inventory.Add(targetItemToSell);
                                                    }
                                                }
                                            }
                                            else if (targetItemToBuy == null)
                                            {
                                                WriteText("\nI have to get back to work, then. Have a good day.");

                                                return;
                                            }
                                            else if (player.WalletValue < targetItemToBuy.MoneyValue)
                                            {
                                                WriteText("\nYe good at jokes. Ye have no money for that. Good day.");

                                                return;
                                            }
                                            else if (player.Inventory.Count > 7)
                                            {
                                                WriteText("\nYe need to make some room in ye bag. I can't sell ye this.");

                                                return;
                                            }
                                            else
                                            {
                                                WriteText($"\nHere is ye {targetItemToBuy.Name}. Now let me just...");

                                                Console.Write($"\nYou give the {targetPerson.Name} {targetItemToBuy.MoneyValue} coppers.\nThe {targetPerson.Name} gives you the {targetItemToBuy.Name}.\n\nGood day.\n");

                                                player.WalletValue = player.WalletValue - targetItemToBuy.MoneyValue;

                                                targetPerson.Inventory.Remove(targetItemToBuy);

                                                player.Inventory.Add(targetItemToBuy);
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

    private static void HandleLook(Character player) // Have the player look around the area.
    {
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
                                        WriteText($"\nYou are currently in the {room.Name}. {room.Description}"); // You move, description of room shows.

                                        foreach (NPC person in room.Persons)
                                        {
                                            Console.Write($"You are in the same area as (the) {person.Name}. {person.Description}\n");
                                        }

                                        foreach (Item item in room.Layout) // What items are in the room?
                                        {
                                            Console.Write($"You can see a(n) {item.Name}.\n");
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

    private static void HandleDrop(Character player, string targetItemName) // Logic for determining what was grabbed.
    {
        Item? itemToRemove = null;
        int maxRoomLayoutSize = 7;

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

                                        foreach (Item item in player.Equipment) // If the item name is equal to entered target, add the item to inventory.
                                        {
                                            if (item.Name.Equals(targetItemName))
                                            {
                                                itemToRemove = item;

                                                break;
                                            }
                                        }

                                        if (itemToRemove == null) // If item does not exist, the game doesn't know what to grab.
                                        {
                                            Console.Write($"Drop what, ye trousers? Maybe ye should check your {inventoryAction}.\n");

                                            return;
                                        }
                                        else
                                        {
                                            // Add item

                                            if (player.Inventory.Contains(itemToRemove) && room.Layout.Count <= maxRoomLayoutSize) // What happens when the item is removed from inventory?
                                            {
                                                Console.Write($"You drop the {itemToRemove.Name}.\n");

                                                player.Inventory.Remove(itemToRemove);

                                                room.Layout.Add(itemToRemove);

                                                return;
                                            }
                                            else if (player.Equipment.Contains(itemToRemove) && room.Layout.Count <= maxRoomLayoutSize)
                                            {
                                                Console.Write($"\nYou drop the {itemToRemove.Name}.\n");

                                                player.Equipment.Remove(itemToRemove);

                                                room.Layout.Add(itemToRemove);

                                                if (itemToRemove.Defense <= 0)
                                                {
                                                    Console.Write($"Your attack decreases by {itemToRemove.Attack}!\n");
                                                }
                                                else if (itemToRemove.Attack <= 0)
                                                {
                                                    Console.Write($"Your defense decreases by {itemToRemove.Defense}!\n");
                                                }
                                                else
                                                {
                                                    Console.Write($"Your attack decreases by {itemToRemove.Attack}!\n");
                                                    Console.Write($"Your defense decreases by {itemToRemove.Defense}!\n");
                                                }

                                                Console.Write($"Current attack: {player.Attack}\n");
                                                Console.Write($"Current defense: {player.Defense}\n");

                                                return;
                                            }
                                            else if (!player.Inventory.Contains(itemToRemove) || !player.Equipment.Contains(itemToRemove))
                                            {
                                                Console.Write("Ye don't have one o' those.\n"); // The item is not in the character's inventory.

                                                return;
                                            }
                                            else
                                            {
                                                Console.Write("There be no more space for that here!\n");
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

    private static void HandleMove(Character player, string target) // Logic for determining movement.
    {
        Town? targetTown = null;
        Building? targetBuilding = null;
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

                                        if (targetRoom.RoomValue != 0 && player.Location[4] != targetRoom.RoomValue)
                                        {
                                            WriteText($"\nYou have moved to the {targetRoom.Name}. {targetRoom.Description}"); // You move, description of room shows.
                                        }

                                        break;
                                    }
                                }

                                foreach (Building toMoveTo in town.Layout) // If the room name is equal to entered target, move there.
                                {
                                    if (target.Equals(toMoveTo.Name) && player.Location[4] != 0)
                                    {
                                        if (toMoveTo.BuildingValue == player.Location[2])
                                        {
                                            Console.Write("Ye are already there.\n");

                                            return;
                                        }
                                        else if (player.Location[3] == 0)
                                        {
                                            player.Location[2] = toMoveTo.BuildingValue;
                                            player.Location[3] = 0;
                                            player.Location[4] = 1;

                                            targetBuilding = toMoveTo;

                                            if (targetBuilding.Name.Equals("OUT"))
                                            {
                                                WriteText($"\nYe have moved OUTSIDE. {targetBuilding.Description}");
                                            }
                                            else
                                            {
                                                WriteText($"\nYe have moved to the {targetBuilding.Name}. {targetBuilding.Description}");
                                            }

                                            return;
                                        }
                                    }
                                }

                                foreach (Town toTravelTo in meridia.Layout) // If the room name is equal to entered target, move there.
                                {
                                    if (target.Equals(toTravelTo.Name) && player.Location[4] != 0 && player.Location[2] == 0)
                                    {
                                        if (toTravelTo.TownValue == player.Location[1])
                                        {
                                            Console.Write("Ye are already there.\n");

                                            return;
                                        }
                                        else if (toTravelTo.TownValue == player.Location[1] + 1 || toTravelTo.TownValue == player.Location[1] - 1 && player.Location[2] == 0)
                                        {
                                            player.Location[1] = toTravelTo.TownValue;
                                            player.Location[2] = 0;
                                            player.Location[3] = 0;
                                            player.Location[4] = 1;

                                            targetTown = toTravelTo;

                                            WriteText($"\nYe have traveled to {targetTown.Name}. {targetTown.Description}");

                                            return;
                                        }
                                    }
                                }

                                if (targetRoom == null && targetBuilding == null && targetTown == null) // If room doesn't exist, you can't go there.
                                {
                                    Console.Write("Ye can currently move to:\n");

                                    foreach (Room room in floor.Layout)
                                    {
                                        if (player.Location[4] < stairLocation)
                                        {
                                            Console.Write($"{room.Name}\n");
                                        }
                                        else if (player.Location[4] == stairLocation && player.Location[4] != room.RoomValue)
                                        {
                                            Console.Write($"{room.Name}\n");
                                        }
                                        else if (room.RoomValue != 0 && player.Location[4] != room.RoomValue)
                                        {
                                            Console.Write($"{room.Name}\n");
                                        }
                                    }
                                    if (player.Location[3] == 0)
                                    {
                                        foreach (Building toGoIn in town.Layout)
                                        {
                                            if (player.Location[2] != toGoIn.BuildingValue && player.Location[4] != 0)
                                            {
                                                Console.Write($"{toGoIn.Name}\n");
                                            }
                                        }
                                    }
                                    if (player.Location[2] == 0)
                                    {
                                        foreach (Town toGoTo in meridia.Layout)
                                        {
                                            if (toGoTo.TownValue == player.Location[1] + 1 || toGoTo.TownValue == player.Location[1] - 1)
                                            {
                                                Console.Write($"{toGoTo.Name}\n");
                                            }
                                        }
                                    }

                                    return;
                                }
                                else if (targetRoom.Name.Equals(up.Name) && player.Location[4] <= stairLocation)
                                {
                                    player.Location[3] += 1;
                                    player.Location[4] = 1;

                                    WriteText(targetRoom.Description);

                                    return;
                                }
                                else if (targetRoom.Name.Equals(down.Name) && player.Location[4] <= stairLocation)
                                {
                                    player.Location[3] -= 1;
                                    player.Location[4] = 1;

                                    WriteText(targetRoom.Description);

                                    return;
                                }
                                else if (player.Location[4] > stairLocation && targetRoom.Name.Equals(up.Name) || player.Location[4] > stairLocation && targetRoom.Name.Equals(down.Name))
                                {
                                    Console.Write("There be no stairs here.\n");

                                    return;
                                }
                                else if (targetRoom.RoomValue == player.Location[4]) // If you are already in the room, you are already there.
                                {
                                    Console.Write("Ye are already there.\n");

                                    return;
                                }

                                foreach (NPC person in targetRoom.Persons)
                                {
                                    Console.Write($"You are in the same area as {person.Name}. {person.Description}\n");
                                }

                                foreach (Item item in targetRoom.Layout) // What items are in the room?
                                {
                                    Console.Write($"You can see a(n) {item.Name}.\n");
                                }

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
        int maxInventorySize = 7;

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
                                            Console.Write($"Grab what, the air? Maybe ye should {lookAction} around.\n");

                                            return;
                                        }
                                        else
                                        {
                                            // Add item

                                            if (player.Inventory.Count <= maxInventorySize || player.Inventory == null) // What happens when the item is added to inventory?
                                            {
                                                Console.Write($"You pick up the {itemToAdd.Name}.\n");

                                                player.Inventory.Add(itemToAdd);

                                                room.Layout.Remove(itemToAdd);

                                                return;
                                            }
                                            else
                                            {
                                                Console.Write("Ye have no more room for that.\n"); // The item is already in the character's inventory.

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

    public static void HandleInventory(Character player) // Shows the current inventory of the player.
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

    public static void HandleEquipment(Character player) // Shows the current equipped items.
    {
        if (player.Equipment == null || player.Equipment.Count < 1)
        {
            Console.Write("You have nothing equipped.\n");
        }

        foreach (Item? item in player.Equipment)
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

    public static void HandleHelp() // The current player needs help. What do the commands do?
    {
        foreach (string playerAction in playerActions)
        {
            if (playerAction == grabAction)
            {
                Console.Write($"\n{grabAction} - Grab something in the room and put it into your inventory.\n");
            }
            else if (playerAction == dropAction)
            {
                Console.Write($"{dropAction} - Drop something from your inventory into the current room.\n");
            }
            else if (playerAction == inventoryAction)
            {
                Console.Write($"{inventoryAction} - Gives a brief description of the player's inventory.\n");
            }
            else if (playerAction == equipmentAction)
            {
                Console.Write($"{equipmentAction} - Gives a brief description of the player's equipped items.\n");
            }
            else if (playerAction == equipAction)
            {
                Console.Write($"{equipAction} - Equip a piece of equipment.\n");
            }
            else if (playerAction == unequipAction)
            {
                Console.Write($"{unequipAction} - Unequip a piece of equipment.\n");
            }
            else if (playerAction == lookAction)
            {
                Console.Write($"{lookAction} - Look around the current area.\n");
            }
            else if (playerAction == talkAction)
            {
                Console.Write($"{talkAction} - Talk to an NPC in the area.\n");
            }
            else if (playerAction == moveAction)
            {
                Console.Write($"{moveAction} - Move to the specified location. If nothing is entered it will list where you can move.\n");
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

    public static string? ValidateAndGetInput() // Prompts if field is null, numeric, or not between 3-25.
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

    public static bool IsInputCorrectLength(string? input) // Checks if field is between 2-25. Takes nullable type string.
    {
        int minimumInputLength = 2;
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