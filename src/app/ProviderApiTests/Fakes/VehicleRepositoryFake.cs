using Common.HttpStatusCodeExceptions;
using DAL.Entities;

namespace DAL.Repositories
{
    public class VehicleRepositoryFake : IVehicleRepository
    {
        public Vehicle GetVehicle(string provider, string company, string carNo)
        {
            Vehicle vehicle = null;

            if (provider.ToLower() == "rolling thunder enterprises" && company.ToLower() == "black diamond sedans" && carNo.ToLower() == "bds-001")
            {
                vehicle = new Vehicle
                {
                    Provider = "Rolling Thunder Enterprises",
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
                throw new NotFoundException(string.Format("The vehicle was not found. provider = '{0}', company = '{1}', carNo = '{2}'.", provider, company, carNo));
            }

            return vehicle;
        }
    }
}
