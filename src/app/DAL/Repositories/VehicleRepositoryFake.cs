using DAL.Entities;
using Common.HttpStatusCodeExceptions;
using System;

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
                    CarNo = "BDS-001",
                    Company = "Black Diamond",
                    IsActive = true,
                    MaxNoOfPassengers = 4,
                    Provider = "Rolling Thunder Enterprises",
                    VehicleType = "Sedan"
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
