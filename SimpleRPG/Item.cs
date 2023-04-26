namespace SimpleRPG;

public class Item
{
    public Item(string name, int attack, int defense, int identifier, int moneyValue) // Create an item with a name, attack/defense values, and a monetary value.
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.Identifier = identifier;
        this.MoneyValue = moneyValue;
    }

    public Item(string name, int attack, int defense, int identifier, int moneyValue, Ability abilityOne, Ability abilityTwo) // Create an item with a name, attack/defense values, and a monetary value.
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.Identifier = identifier;
        this.MoneyValue = moneyValue;

        this.AbilityList = new List<Ability>();

        this.AbilityList.Add(abilityOne);
        this.AbilityList.Add(abilityTwo);
    }

    public Item(string name, int attack, int defense, int identifier, int moneyValue, Ability abilityOne, Ability abilityTwo, Ability abilityThree, Ability abilityFour) // Create an item with a name, attack/defense values, and a monetary value.
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.Identifier = identifier;
        this.MoneyValue = moneyValue;

        this.AbilityList = new List<Ability>();

        this.AbilityList.Add(abilityOne);
        this.AbilityList.Add(abilityTwo);
        this.AbilityList.Add(abilityThree);
        this.AbilityList.Add(abilityFour);
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

    private List<Ability> abilityList;
    public List<Ability> AbilityList // What items are in this room?
    {
        get { return abilityList; }
        set
        {
            abilityList = value;
        }
    }

    private int identifier; // Item identity.
    public int Identifier
    {
        get { return identifier; }
        set
        {
            identifier = value;
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