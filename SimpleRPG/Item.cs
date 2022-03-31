namespace SimpleRPG;

public class Item
{
    public Item(string name, int attack, int defense, int moneyValue) // Create an item with a name, attack/defense values, and a monetary value.
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.MoneyValue = moneyValue;
    }

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

    private int moneyValue; // What can you sell it for?
    public int MoneyValue
    {
        get { return moneyValue; }
        set
        {
            moneyValue = value;
        }
    }

    public override string? ToString() // ToString override. Returns the item name as a string.
    {
        return name;
    }
}