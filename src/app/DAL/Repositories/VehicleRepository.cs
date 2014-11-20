using Common.HttpStatusCodeExceptions;
using DAL.Entities;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repositories
{
    public class VehicleRepository
    {
        private const string GET_VEHICLE = "execute dbo.GetVehicle '{0}', '{1}', '{2}';";

        public Vehicle GetVehicle(string provider, string company, string carNo)
        {
            Vehicle vehicle = null;

            using (var context = new ProviderContext())
            {
                vehicle = context.Database.SqlQuery<Vehicle>(string.Format(GET_VEHICLE, provider, company, carNo)).FirstOrDefault();
            }

            if (vehicle == null)
            {
                throw new NotFoundException(string.Format("Vehicle was not found. Provider = '{0}', Company = '{1}', CarNo = '{2}'.", provider, company, carNo));
            }

            return vehicle;
        }
    }
}
