namespace DAL.Entities
{
    public class Vehicle
    {
        public string Provider { get; set; }

        public string Company { get; set; }

        public string CarNo { get; set; }

        public string VehicleType { get; set; }

        public byte MaxNoOfPassengers { get; set; }

        public bool IsActive { get; set; }
    }
}
