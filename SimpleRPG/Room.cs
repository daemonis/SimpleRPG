namespace SimpleRPG
{
    public class Room
    {
        public Room(string name, int roomNumber)
        {
            this.Name = name;
            this.RoomValue = roomNumber;
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

        private int roomValue;
        public int RoomValue
        {
            get { return roomValue; }
            set
            {
                roomValue = value;
            }
        }

        private List<Item> layout;
        public List<Item> Layout
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
