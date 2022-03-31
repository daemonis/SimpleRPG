namespace SimpleRPG
{
    public class Floor
    {
        public Floor(int floorValue) // What floor are we on? Give the floor a value.
        {
            this.Name = $"FLOOR {floorValue + 1}";
            this.FloorValue = floorValue;
        }

        private string name;
        public string Name // Floor name.
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private int floorValue;
        public int FloorValue // Coordinate value.
        {
            get { return floorValue; }
            set
            {
                floorValue = value;
            }
        }

        private List<Room> layout;
        public List<Room> Layout // How many rooms are on this floor?
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
