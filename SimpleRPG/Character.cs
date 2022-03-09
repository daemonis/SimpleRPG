namespace SimpleRPG
{
    public class Character
    {
        private string? name;
        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        private string? location;
        public string? Location // Player location. Flavor text if in game town is chosen.
        {
            get { return location; }
            set
            {
                if (value == "Steelswamp" || value == "steelswamp")
                {
                    Program.WriteText($"\nAh, rainy ol' {value}. creepy place, that is. There be a strange inn there.\n");
                }
                else if (value == "Ironhold" || value == "ironhold")
                {
                    Program.WriteText($"\nAh, busy ol' {value}. Scary place, that is. They make weapons there.\n");
                }
                else if (value == "Meadowland" || value == "meadowland")
                {
                    Program.WriteText($"\nAh, peaceful ol' {value}. Relaxing place, that is. They sell medicinal herbs there.\n");
                }
                else if (value == "Forestview" || value == "forestview")
                {
                    Program.WriteText($"\nAh, quiet ol' {value}. Interesting place, that is. They make nice bows there.\n");
                }
                else if (value == "Groverest" || value == "groverest")
                {
                    Program.WriteText($"\nAh, good ol' {value}. Historical place, that is. The first Holy Church was built there.\n");
                }
                else
                {
                    Program.WriteText("\nNever heard o' there before, but alright then.\n");
                }
                location = value;
            }
        }
        private string? gender;
        public string? Gender
        {
            get { return gender; }
            set
            {
                gender = value;
            }
        }
        private int level = 1;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
            }
        }
        private int experience;
        public int Experience // Level up mechanic.
        {
            get { return experience; }
            set
            {
                int maxLevelExperience = 50;

                if (value >= maxLevelExperience)
                {
                    value %= maxLevelExperience;

                    level++;

                    Console.Write($"\nYou are now level {level}!\n");
                }
                else
                {
                    experience = value;
                }
            }
        }
        private int hitPoints = 25;
        public int HitPoints // Amount of HP. When HP reaches 0, the player dies. Maximum HP a player can have is 40.
        {
            get { return hitPoints; }
            set
            {
                int maxHitPoints = 40;
                int characterDeath = 0;

                if (value <= characterDeath)
                {
                    Console.Write($"\nYou have died! Fare thee well, {name}.\n\nPress any key to exit the game...\n");

                    Console.ReadKey(true);

                    Environment.Exit(0);
                }
                else if (value >= maxHitPoints)
                {
                    hitPoints = maxHitPoints;

                    Console.Write($"\nYou already have max HP! You can't have more than {maxHitPoints} HP.\n");
                }
                else
                {
                    hitPoints = value;
                }
            }
        }
    }
}