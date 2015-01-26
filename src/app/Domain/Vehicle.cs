namespace Domain
{
    public class Vehicle
    {
        public int ProviderId { get; private set; }

        public string CompanyName { get; private set; }

        public string CarNo { get; private set; }

        public string Year { get; private set; }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string VehicleType { get; private set; }

        public byte MaxNoOfPassengers { get; private set; }

        public byte MaxNoOfLuggage { get; private set; }

        public string RegulatingAgencyLicenseNo { get; set; }

        public string VinNo { get; private set; }

        public string State { get; private set; }

        public string LicensePlate { get; private set; }

        public bool IsActive { get; private set; }

        public static Vehicle Create(int providerId, string companyName, string carNo, string year, string make, string model, string color, string vehicleType, byte maxNoOfPassengers, byte maxNoOfLuggage, string regulatingAgencyLicenseNo, string vinNo, string state, string licensePlate, bool isActive)
        {
            var newVehicle = new Vehicle()
            {
                ProviderId = providerId,
                CompanyName = companyName,
                CarNo = carNo,
                Year = year,
                Make = make,
                Model = model,
                Color = color,
                VehicleType = vehicleType,
                MaxNoOfPassengers = maxNoOfPassengers,
                VinNo = vinNo,
                State = state,
                LicensePlate = licensePlate,
                IsActive = isActive
            };

            return newVehicle;
        }
    }
}