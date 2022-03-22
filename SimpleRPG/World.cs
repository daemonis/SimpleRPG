namespace SimpleRPG
{
    public class World
    {
        private string name = "MERIDIA";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private int worldValue = 0;
        public int WorldValue
        {
            get { return worldValue; }
            set
            {
                worldValue = value;
            }
        }

        private List<Town> layout;
        public List<Town> Layout
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
