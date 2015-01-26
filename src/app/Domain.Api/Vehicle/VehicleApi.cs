using DAL.Repositories;

namespace Domain.Api.Vehicles
{
    public class VehicleApi : IVehicleApi
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleApi(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle GetVehicle(int providerId, string company, string carNo)
        {
            Vehicle vehicle = null;

            var ev = _vehicleRepository.GetVehicle(company, carNo);

            if (ev != null)
            {
                vehicle = Vehicle.Create(providerId, ev.CompanyName, ev.CarNo, ev.Year, ev.Make, ev.Model, ev.Color, ev.VehicleType, ev.MaxNoOfPassengers, ev.MaxNoLuggage, ev.RegulatingAgencyLicenseNo, ev.VinNo, ev.State, ev.LicensePlate, ev.IsActive);
            }

            return vehicle;
        }
    }
}
