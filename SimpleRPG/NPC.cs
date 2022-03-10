namespace SimpleRPG
{
    public class NPC
    {
        public NPC()
        {
            Name = "Adventurer";
            Level = 1;
            HitPoints = 25;
        }
        public NPC(string name, int level, int hitPoints)
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
