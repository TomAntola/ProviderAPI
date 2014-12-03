using DAL.Repositories;

namespace Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle GetVehicle(string provider, string company, string carNo)
        {
            Vehicle vehicle = null;

            var ev = _vehicleRepository.GetVehicle(provider, company, carNo);

            if (ev != null)
            {
                vehicle = Vehicle.Create(ev.Provider, ev.Company, ev.CarNo, ev.VehicleType, ev.MaxNoOfPassengers, ev.IsActive);
            }

            return vehicle;
        }
    }
}
