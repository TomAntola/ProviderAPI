using Common.HttpStatusCodeExceptions;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class VehicleRepository
    {
        private const string GET_VEHICLE = "select p.provider_name Provider, null Company, v.provider_vehicle_id CarNo, vt.vehicle_type VehicleType, v.max_capacity MaxNoOfPassengers, v.is_active IsActive from vehicle v inner join provider p on v.provider_id = p.provider_id inner join vehicle_type vt on v.vehicle_type_id = vt.vehicle_type_id where p.provider_name = '{0}' and v.provider_vehicle_id = '{1}'";

        public Vehicle GetVehicle(string provider, string company, string carNo)
        {
            Vehicle vehicle = null;

            using (var context = new ProviderContext())
            {
                vehicle = context.Database.SqlQuery<Vehicle>(string.Format(GET_VEHICLE, provider, carNo)).FirstOrDefault();
            }

            if (vehicle == null)
            {
                throw new NotFoundException(string.Format("Vehicle was not found. Provider = '{0}', Company = '{1}', CarNo = '{2}'.", provider, company, carNo));
            }

            return vehicle;
        }
    }
}
