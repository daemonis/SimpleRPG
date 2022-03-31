namespace SimpleRPG
{
    public class Building
    {
        public Building(string name, int buildingValue) // The building has a name and a coordinate value.
        {
            this.Name = name;
            this.BuildingValue = buildingValue;
        }

        private string name;
        public string Name // Building name.
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private int buildingValue;
        public int BuildingValue // Coordinate value.
        {
            get { return buildingValue; }
            set
            {
                buildingValue = value;
            }
        }

        private List<Floor> layout;
        public List<Floor> Layout // How many floors are in the building?
        {
            get { return layout; }
            set
            {
                layout = value;
            }
        }
    }
}
