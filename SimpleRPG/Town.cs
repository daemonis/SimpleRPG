namespace SimpleRPG;

public class Town
{
    public Town(string? name) // Overload, just town name.
    {
        this.name = name;
    }

    public Town(string? name, string? description) // Overload, town name with a description.
    {
        this.name = name;
        this.description = description;
    }

    public Town(string? name, string? description, string? intro) // Overload, specific town name in the game with a description and intro flavor text.
    {
        this.Name = name;
        this.Description = description;
        this.Intro = intro;
    }

    public Town(string? name, string? description, int townNumber, string? intro) // Overload, specific town name in the game with a description and intro flavor text.
    {
        this.Name = name;
        this.Description = description;
        this.TownNumber = townNumber;
        this.Intro = intro;
    }

    private string? name; // Town name.
    public string? Name
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

    private int townNumber;
    public int TownNumber
    {
        get { return townNumber; }
        set
        {
            townNumber = value;
        }
    }

    //private List<Building> layout;
    //public List<Building> Layout
    //{
    //    get { return layout; }
    //    set
    //    {
    //        layout = value;
    //    }
    //}

    private string? intro; // Flavor text for if the character chooses an in game town.
    public string? Intro
    {
        get { return intro; }
        set
        {
            intro = value;
        }
    }
}