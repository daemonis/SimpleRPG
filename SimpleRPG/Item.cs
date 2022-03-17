namespace SimpleRPG;

public class Item
{
    private string name; // Item name.
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
        }
    }
    private int attack; // Item attack.
    public int Attack
    {
        get { return attack; }
        set
        {
            attack = value;
        }
    }
    private int defense; // Item defense.
    public int Defense
    {
        get { return defense; }
        set
        {
            defense = value;
        }
    }

    public Item(string name, int attack, int defense) // Create an item with a name and attack/defense values.
    {
        this.name = name;
        this.attack = attack;
        this.defense = defense;
    }

    public override string? ToString() // ToString override. Returns the item name as a string.
    {
        return name;
    }
}