using DAL.Repositories;
using Domain;

namespace Services.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle GetVehicle(string company, string carNo)
        {
            Vehicle vehicle = null;

            var ev = _vehicleRepository.GetVehicle(company, carNo);

            if (ev != null)
            {
                vehicle = Vehicle.Create(ev.CompanyId, ev.CompanyName, ev.CarNo, ev.Year, ev.Make, ev.Model, ev.Color, ev.VehicleType, ev.MaxNoOfPassengers, ev.VinNo, ev.IsActive);
            }

            return vehicle;
        }
    }
}
