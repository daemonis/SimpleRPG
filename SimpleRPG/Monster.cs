namespace SimpleRPG
{
    public class Monster
    {
        public Monster()
        {
            Name = "Ghoul";
            Level = 1;
            HitPoints = 10;
        }
        public Monster(string name)
        {
            Name = name;
            Level = 1;
            HitPoints = 10;
        }
        public Monster(string name, int level, int hitPoints)
        {
            Name = name;
            Level = level;
            HitPoints = hitPoints;
        }
        private string name;
        public string Name { get; }

        private int level;
        public int Level { get; }

        private int hitPoints;
        public int HitPoints { get; }
    }
}
