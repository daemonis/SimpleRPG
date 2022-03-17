namespace SimpleRPG;

public class Town
{
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

    private string? intro; // Flavor text for if the character chooses an in game town.
    public string? Intro
    {
        get { return intro; }
        set
        {
            intro = value;
        }
    }

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
        this.name = name;
        this.description = description;
        this.intro = intro;
    }
}