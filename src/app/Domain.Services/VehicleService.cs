using DAL.Repositories;

namespace Domain.Services
{
    public class VehicleService
    {
        public Vehicle GetVehicle(string provider, string company, string carNo)
        {
            Vehicle vehicle = null;

            var vehicleRepo = new VehicleRepository();
            var ev = vehicleRepo.GetVehicle(provider, company, carNo);

            if (ev != null)
            {
                vehicle = Vehicle.Create(ev.Provider, ev.Company, ev.CarNo, ev.VehicleType, ev.MaxNoOfPassengers, ev.IsActive);
            }

            return vehicle;
        }
    }
}
