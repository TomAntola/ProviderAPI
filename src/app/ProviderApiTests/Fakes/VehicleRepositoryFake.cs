using Common.HttpStatusCodeExceptions;
using DAL.Entities;

namespace DAL.Repositories
{
    public class VehicleRepositoryFake : IVehicleRepository
    {
        public Vehicle GetVehicle(string company, string carNo)
        {
            Vehicle vehicle = null;

            if (string.Compare(company, "Black Diamond Sedans", true) == 0 && string.Compare(carNo, "BDS-001", true) == 0)
            {
                vehicle = new Vehicle
                {
                    CompanyId = "2",
                    CompanyName = "Black Diamond",
                    CarNo = "BDS-001",
                    Year = "2011",
                    Make = "Lincoln",
                    Model = "TOWN CAR",
                    Color = "Black",
                    MaxNoOfPassengers = 4,
                    VehicleType = "Sedan",
                    VinNo = "XD90213UIDJJ654",
                    IsActive = true
                };
            }

            if (vehicle == null)
            {
                throw new NotFoundException(string.Format("The vehicle was not found. company = '{1}', carNo = '{2}'.", company, carNo));
            }

            return vehicle;
        }
    }
}
