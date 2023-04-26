namespace SimpleRPG
{
    public class Ability
    {
        public Ability(string name, int attack, int defense, string description) // Create an item with a name, attack/defense values, and a monetary value.
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
            this.Description = description;
        }

        private string name; // Ability name.
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private int attack; // Ability attack.
        public int Attack
        {
            get { return attack; }
            set
            {
                attack = value;
            }
        }

        private int defense; // Ability defense.
        public int Defense
        {
            get { return defense; }
            set
            {
                defense = value;
            }
        }

        private string description; // Ability name.
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }
    }
}
