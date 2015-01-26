namespace Web.Api.Representations
{
    public class Vehicle
    {
        public Vehicle(Domain.Vehicle vehicle)
        {
            ProviderId = vehicle.ProviderId;
            CompanyName = vehicle.CompanyName;
            CarNo = vehicle.CarNo;
            Color = vehicle.Color;
            IsActive = vehicle.IsActive;
            LicensePlate = vehicle.LicensePlate;
            Make = vehicle.Make;
            MaxNoOfPassengers = vehicle.MaxNoOfPassengers;
            MaxNoLuggage = vehicle.MaxNoOfLuggage;
            RegulatingAgencyLicenseNo = vehicle.RegulatingAgencyLicenseNo;
            Model = vehicle.Model;
            State = vehicle.State;
            VehicleType = vehicle.VehicleType;
            VinNo = vehicle.VinNo;
            Year = vehicle.Year;
        }

        public int ProviderId { get; set; }

        public string CompanyName { get; set; }

        public string CarNo { get; set; }

        public string Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string VehicleType { get; set; }

        public byte MaxNoOfPassengers { get; set; }

        public byte MaxNoLuggage { get; set; }

        public string RegulatingAgencyLicenseNo { get; set; }

        public string VinNo { get; set; }

        public string State { get; set; }

        public string LicensePlate { get; set; }

        public bool IsActive { get; set; }
    }
}