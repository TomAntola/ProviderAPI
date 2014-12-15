namespace Domain
{
    public class Vehicle
    {
        public Vehicle() { }

        public string CompanyId { get; private set; }

        public string CompanyName { get; private set; }

        public string CarNo { get; private set; }

        public string Year { get; private set; }

        public string Make { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string VehicleType { get; private set; }

        public byte MaxNoOfPassengers { get; private set; }

        public string VinNo { get; private set; }

        public bool IsActive { get; private set; }

        public static Vehicle Create(string companyId, string companyName, string carNo, string year, string make, string model, string color, string vehicleType, byte maxNoOfPassengers, string vinNo, bool isActive)
        {
            var newVehicle = new Vehicle()
            {
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