namespace DAL.Entities
{
    public class Vehicle
    {
        public string Provider { get; private set; }

        public string Company { get; private set; }

        public string CarNo { get; private set; }

        public string VehicleType { get; private set; }

        public byte MaxNoOfPassengers { get; private set; }

        public bool IsActive { get; private set; }
    }
}
