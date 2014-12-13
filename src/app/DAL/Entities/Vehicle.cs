namespace DAL.Entities
{
    public class Vehicle
    {
        public string Provider { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CarNo { get; set; }

        public string Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string VehicleType { get; set; }

        public byte MaxNoOfPassengers { get; set; }

        public string VinNo { get; set; }

        public bool IsActive { get; set; }
    }
}
