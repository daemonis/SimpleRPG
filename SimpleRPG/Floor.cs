namespace SimpleRPG
{
    public class Floor
    {
        public Floor(int floorNumber)
        {
            this.Name = $"FLOOR {floorNumber}";
            this.FloorValue = floorNumber;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private int floorValue;
        public int FloorValue
        {
            get { return floorValue; }
            set
            {
                floorValue = value;
            }
        }

        private List<Room> layout;
        public List<Room> Layout
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
