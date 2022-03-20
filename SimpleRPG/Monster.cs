namespace SimpleRPG;

public class Monster
{
    public Monster(string name) // Generic level 1 monster with a custom name.
    {
        this.Name = name;
        this.Level = level;
        this.HitPoints = hitPoints;
        this.IsAlive = isAlive;
    }

    public Monster(string name, int level, int hitPoints) // Custom monster.
    {
        this.Name = name;
        this.Level = level;
        this.HitPoints = hitPoints;
        this.IsAlive = isAlive;
    }

    private string name = "Ghoul"; // Default name.
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
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

    private int hitPoints = 10; // Amount of HP. When HP reaches 0 the monster dies. Maximum HP a NPC can have is 40.
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

                Console.Write($"\n{Name} has been slain!\n");
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

    private bool isAlive; // Is the monster alive? See HitPoints.
    public bool IsAlive
    {
        get { return isAlive; }
        set
        {
            isAlive = value;
        }
    }
}