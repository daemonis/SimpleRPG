namespace SimpleRPG
{
    public class Ability
    {
        public Ability(string name, int attack, int defense) // Create an item with a name, attack/defense values, and a monetary value.
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
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
    }
}
