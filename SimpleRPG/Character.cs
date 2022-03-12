namespace SimpleRPG
{
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

        private string? location;
        public string? Location // Character location.
        {
            get { return location; }
            set
            {
                location = value;
            }
        }

        private string? gender; // Character gender.
        public string? Gender
        {
            get { return gender; }
            set
            {
                gender = value;
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

        private string[]? inventory; // Inventory array.
        public string[] Inventory
        {
            get { return inventory; }
            set
            {
                inventory = value;
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
}