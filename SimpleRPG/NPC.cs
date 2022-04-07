namespace SimpleRPG;

public class NPC
{
    public NPC(string name, string description) // Generic level 1 NPC with custom name.
    {
        this.Name = name;
        this.Level = level;
        this.HitPoints = hitPoints;
        this.Inventory = inventory;
        this.Description = description;
        this.IsAlive = isAlive;
    }

    public NPC(string name, int level, int hitPoints, string description) // Custom NPC.
    {
        this.Name = name;
        this.Level = level;
        this.HitPoints = hitPoints;
        this.Inventory = inventory;
        this.Description = description;
        this.IsAlive = isAlive;
    }

    private string name = "Adventurer"; // Default name.
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
        }
    }

    private string? description; // Description of specified town.
    public string? Description
    {
        get { return description; }
        set
        {
            description = value;
        }
    }

    private int level = 1; // Default level.
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

    private int attack = 5; // Attack power.
    public int Attack
    {
        get { return attack; }
        set
        {
            attack = value;
        }
    }

    private int defense = 1; // Defense power.
    public int Defense
    {
        get { return defense; }
        set
        {
            defense = value;
        }
    }

    private int hitPoints = 25; // Amount of HP. When HP reaches 0 the NPC dies. Maximum HP a NPC can have is 40.
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

                hitPoints = value;

                Console.Write($"\n{Name} has died...\n");
            }
            else if (value >= maxHitPoints)
            {
                isAlive = true;

                hitPoints = maxHitPoints;

                Console.Write($"\n{Name} already has max HP! {Name} can't have more than {maxHitPoints} HP.\n");
            }
            else
            {
                isAlive = true;

                hitPoints = value;
            }
        }
    }

    private bool isAlive; // Is the NPC alive? See HitPoints.
    public bool IsAlive
    {
        get { return isAlive; }
        set
        {
            isAlive = value;
        }
    }
}