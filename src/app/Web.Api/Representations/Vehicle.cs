namespace Web.Api.Representations
{
    public class Vehicle
    {
        public Vehicle(Domain.Vehicle vehicle)
        {
            CarNo = vehicle.CarNo;
            Color = vehicle.Color;
            CompanyId = vehicle.CompanyId;
            CompanyName = vehicle.CompanyName;
            IsActive = vehicle.IsActive;
            Make = vehicle.Make;
            MaxNoOfPassengers = vehicle.MaxNoOfPassengers;
            Model = vehicle.Model;
            VehicleType = vehicle.VehicleType;
            VinNo = vehicle.VinNo;
            Year = vehicle.Year;
        }

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