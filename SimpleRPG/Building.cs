namespace SimpleRPG
{
    public class Building
    {
        public Building(string name, int buildingNumber)
        {
            this.Name = name;
            this.BuildingNumber = buildingNumber;
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

        private int buildingNumber;
        public int BuildingNumber
        {
            get { return buildingNumber; }
            set
            {
                buildingNumber = value;
            }
        }

        //private List<Floor> layout;
        //public List<Floor> Layout
        //{
        //    get { return layout; }
        //    set
        //    {
        //        layout = value;
        //    }
        //}
    }
}
