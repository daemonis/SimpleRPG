namespace SimpleRPG
{
    public class Room
    {
        public Room(string name, int roomValue, string desc) // Room must be made with a name, coordinate value, and a description.
        {
            this.RoomValue = roomValue;
            this.Name = name;
            this.Description = desc;
        }

        private string name;
        public string Name // Room name.
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private int roomValue;
        public int RoomValue // Coordinate value.
        {
            get { return roomValue; }
            set
            {
                roomValue = value;
            }
        }

        private string description;
        public string Description // A visual description of the room for the player.
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        private List<Item> layout;
        public List<Item> Layout // What items are in this room?
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
