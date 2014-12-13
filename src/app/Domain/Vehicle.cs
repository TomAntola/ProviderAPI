namespace Domain
{
    public class Vehicle
    {
        public Vehicle() { }

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

        public static Vehicle Create(string provider, string companyId, string companyName, string carNo, string year, string make, string model, string color, string vehicleType, byte maxNoOfPassengers, string vinNo, bool isActive)
        {
            var newVehicle = new Vehicle()
            {
                Provider = provider,
                CompanyId = companyId,
                CompanyName = companyName,
                CarNo = carNo,
                Year = year,
                Make = make,
                Model = model,
                Color = color,
                VehicleType = vehicleType,
                MaxNoOfPassengers = maxNoOfPassengers,
                VinNo = vinNo,
                IsActive = isActive
            };

            return newVehicle;
        }
    }
}