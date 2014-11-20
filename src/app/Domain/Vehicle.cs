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

        public Vehicle GetVehicle(string provider, string company, string carNo)
        {
            var vehicle = new Vehicle
            {
                Provider = this.Provider,
                Company = this.Company,
                CarNo = this.CarNo,
                VehicleType = this.VehicleType,
                MaxNoOfPassengers = this.MaxNoOfPassengers,
                IsActive = this.IsActive
            };

            return vehicle;
        }

        public void SetVehicle(string provider, string company, string carNo, string vehicleType, byte maxNoOfPassengers, bool isActive)
        {
            this.Provider = provider;
            this.Company = company;
            this.CarNo = this.CarNo;
            this.VehicleType = vehicleType;
            this.MaxNoOfPassengers = maxNoOfPassengers;
            this.IsActive = isActive;
        }
    }
}