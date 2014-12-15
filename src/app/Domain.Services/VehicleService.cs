using DAL.Repositories;
using Domain;

namespace Services
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
                vehicle = Vehicle.Create(ev.Provider, ev.CompanyId, ev.CompanyName, ev.CarNo, ev.Year, ev.Make, ev.Model, ev.Color, ev.VehicleType, ev.MaxNoOfPassengers, ev.VinNo, ev.IsActive);
            }

            return vehicle;
        }
    }
}
