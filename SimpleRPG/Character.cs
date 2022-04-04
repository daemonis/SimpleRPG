namespace SimpleRPG;

public class Character
{
    private string? name; // Character name.
    public string? Name
    {
        get { return name; }
        set
        {
            name = value;
        }
    }

    private Town? homeTown; // Character home location.
    public Town? HomeTown
    {
        get { return homeTown; }
        set
        {
            homeTown = value;
        }
    }

    private int[] location; // Character's current location.
    public int[] Location
    {
        get { return location; }
        set
        {
            location = value;
        }
    }

    private int level = 1; // Character level.
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
        }
    }

    private List<Item>? inventory; // Inventory list.
    public List<Item>? Inventory
    {
        get { return inventory; }
        set
        {
            inventory = value;
        }
    }

    private int experience; // Amount of experience points.
    public int Experience // Level up mechanic.
    {
        get { return experience; }
        set
        {
            int maxLevelExperience = 50;

            if (value >= maxLevelExperience)
            {
                experience %= maxLevelExperience;

                level++;

                Console.Write($"\nYou are now level {level}!\n");
            }
            else
            {
                experience = value;
            }
        }
    }

    private int baseAttack = 5; // Base attack.
    public int BaseAttack
    {
        get { return baseAttack; }
        set
        {
            baseAttack = value;
        }
    }

    public int Attack // Current attack.
    {
        get
        {
            int itemAttack = 0;

            foreach (Item item in inventory)
            {
                itemAttack += item.Attack;
            }
            return baseAttack + itemAttack;
        }
    }

    private int baseDefense = 1; // Base defense.
    public int BaseDefense
    {
        get { return baseDefense; }
        set
        {
            baseDefense = value;
        }
    }

    public int Defense // Current defense.
    {
        get
        {
            int itemDefense = 0;
            foreach (Item item in inventory)
            {
                itemDefense += item.Defense;
            }
            return baseDefense + itemDefense;
        }
    }

    private int hitPoints = 25; // Amount of HP. When HP reaches 0, the player dies. Maximum HP a player can have is 40.
    public int HitPoints
    {
        get { return hitPoints; }
        set
        {
            int maxHitPoints = 40;
            int death = 0;

            if (value <= death)
            {
                isAlive = false;
            }
            else if (value >= maxHitPoints)
            {
                isAlive = true;

                hitPoints = maxHitPoints;

                Console.Write($"\nYou already have max HP! You can't have more than {maxHitPoints} HP.\n");
            }
            else
            {
                isAlive = true;

                hitPoints = value;
            }
        }
    }

    private bool isAlive; // Is the character alive? See HitPoints.
    public bool IsAlive
    {
        get { return isAlive; }
        set
        {
            isAlive = value;
        }
    }
}