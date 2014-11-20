namespace Domain
{
    public class Vehicle
    {
        public Vehicle() { }

        public string Provider { get; private set; }

        public string Company { get; private set; }

        public string CarNo { get; private set; }

        public string VehicleType { get; private set; }

        public byte MaxNoOfPassengers { get; private set; }

        public bool IsActive { get; private set; }

        public static Vehicle Create(string provider, string company, string carNo, string vehicleType, byte maxNoOfPassengers, bool isActive)
        {
            var newVehicle = new Vehicle()
            {
                Provider = provider,
                Company = company,
                CarNo = carNo,
                VehicleType = vehicleType,
                MaxNoOfPassengers = maxNoOfPassengers,
                IsActive = isActive
            };

            return newVehicle;
        }
    }
}