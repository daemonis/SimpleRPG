namespace SimpleRPG
{
    public class Room
    {
        public Room(string name, int roomNumber)
        {
            this.Name = name;
            this.RoomNumber = roomNumber;
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

        private int roomNumber;
        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                roomNumber = value;
            }
        }

        //private List<Item> layout;
        //public List<Item> Layout
        //{
        //    get { return layout; }
        //    set
        //    {
        //        layout = value;
        //    }
        //}
    }
}
