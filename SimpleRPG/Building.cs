namespace SimpleRPG
{
    public class Building
    {
        public Building(string name, int buildingValue)
        {
            this.Name = name;
            this.BuildingValue = buildingValue;
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

        private int buildingValue;
        public int BuildingValue
        {
            get { return buildingValue; }
            set
            {
                buildingValue = value;
            }
        }

        private List<Floor> layout;
        public List<Floor> Layout
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
