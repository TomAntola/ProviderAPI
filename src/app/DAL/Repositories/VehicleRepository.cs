using Common.HttpStatusCodeExceptions;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private const string GET_VEHICLE = "execute dbo.GetVehicle '{0}', '{1}';";

        public Vehicle GetVehicle(string company, string carNo)
        {
            Vehicle vehicle = null;

            using (var context = new ProviderContext())
            {
                vehicle = context.Database.SqlQuery<Vehicle>(string.Format(GET_VEHICLE, company, carNo)).FirstOrDefault();
            }

            if (vehicle == null)
            {
                throw new NotFoundException(string.Format("Vehicle was not found. Company = '{0}', CarNo = '{1}'.", company, carNo));
            }

            return vehicle;
        }
    }
}
