using DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class VehicleTests
    {
        [Test]
        public void VehicleRepositoryGetVehicleReturnsExpectedVehicle()
        {
            var vehicleDatabase = new List<DAL.Entities.Vehicle>
            {
                new DAL.Entities.Vehicle { Provider = "Moq Provider", Company = "Moq Company", CarNo = "Moq-001", IsActive = true, MaxNoOfPassengers = 4, VehicleType = "Sedan"},
                new DAL.Entities.Vehicle { Provider = "Moq Provider", Company = "Moq Company", CarNo = "Moq-002", IsActive = true, MaxNoOfPassengers = 4, VehicleType = "Sedan"},
                new DAL.Entities.Vehicle { Provider = "Moq Provider", Company = "Moq Company", CarNo = "Moq-101", IsActive = true, MaxNoOfPassengers = 6, VehicleType = "SUV"}
            };

            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository
                .Setup(x => x.GetVehicle(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string Provider, string company, string carno) => vehicleDatabase.Where(vd => vd.Provider == Provider && vd.Company == company && vd.CarNo == carno).FirstOrDefault());

            var moqVehicleRepository = vehicleRepository.Object;

            DAL.Entities.Vehicle expectedVehicle = new DAL.Entities.Vehicle
            {
                Provider = "Moq Provider",
                Company = "Moq Company",
                CarNo = "Moq-001",
                IsActive = true,
                MaxNoOfPassengers = 4,
                VehicleType = "Sedan"
            };

            var vehicle = moqVehicleRepository.GetVehicle("Moq Provider", "Moq Company", "Moq-001");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(expectedVehicle.Provider, vehicle.Provider);
            Assert.AreEqual(expectedVehicle.Company, vehicle.Company);
            Assert.AreEqual(expectedVehicle.CarNo, vehicle.CarNo);
            Assert.AreEqual(expectedVehicle.VehicleType, vehicle.VehicleType);
            Assert.AreEqual(expectedVehicle.MaxNoOfPassengers, vehicle.MaxNoOfPassengers);
            Assert.AreEqual(expectedVehicle.IsActive, vehicle.IsActive);
        }

        [Test]
        public void VehicleServiceGetVehicleReturnsExpectedVehicle()
        {
            var vehicleDatabase = new List<DAL.Entities.Vehicle>
            {
                new DAL.Entities.Vehicle { Provider = "Moq Provider", Company = "Moq Company", CarNo = "Moq-001", IsActive = true, MaxNoOfPassengers = 4, VehicleType = "Sedan"},
                new DAL.Entities.Vehicle { Provider = "Moq Provider", Company = "Moq Company", CarNo = "Moq-002", IsActive = true, MaxNoOfPassengers = 4, VehicleType = "Sedan"},
                new DAL.Entities.Vehicle { Provider = "Moq Provider", Company = "Moq Company", CarNo = "Moq-101", IsActive = true, MaxNoOfPassengers = 6, VehicleType = "SUV"}
            };

            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository
                .Setup(x => x.GetVehicle(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string Provider, string company, string carno) => vehicleDatabase.Where(vd => vd.Provider == Provider && vd.Company == company && vd.CarNo == carno).FirstOrDefault());

            var vehicleService = new Domain.Services.VehicleService(vehicleRepository.Object);

            Domain.Vehicle expectedVehicle = Domain.Vehicle.Create("Moq Provider", "Moq Company", "Moq-001", "Sedan", 4, true);
            Domain.Vehicle vehicle = vehicleService.GetVehicle("Moq Provider", "Moq Company", "Moq-001");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(expectedVehicle.Provider, vehicle.Provider);
            Assert.AreEqual(expectedVehicle.Company, vehicle.Company);
            Assert.AreEqual(expectedVehicle.CarNo, vehicle.CarNo);
            Assert.AreEqual(expectedVehicle.VehicleType, vehicle.VehicleType);
            Assert.AreEqual(expectedVehicle.MaxNoOfPassengers, vehicle.MaxNoOfPassengers);
            Assert.AreEqual(expectedVehicle.IsActive, vehicle.IsActive);
        }
    }
}
