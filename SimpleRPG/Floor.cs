namespace SimpleRPG
{
    public class Floor
    {
        public Floor(int floorNumber)
        {
            this.Name = $"FLOOR {floorNumber}";
            this.FloorNumber = floorNumber;
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

        private int floorNumber;
        public int FloorNumber
        {
            get { return floorNumber; }
            set
            {
                floorNumber = value;
            }
        }

        //private List<Room> layout;
        //public List<Room> Layout
        //{
        //    get { return layout; }
        //    set
        //    {
        //        layout = value;
        //    }
        //}
    }
}
