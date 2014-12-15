using DAL.Repositories;
using Moq;
using NUnit.Framework;
using Services.Vehicles;
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
                new DAL.Entities.Vehicle { CompanyId = "2", CompanyName = "Moq Company", CarNo = "Moq-001", Year = "2011", Make = "Lincoln", Model = "Town Car", Color = "Black", MaxNoOfPassengers = 4, VehicleType = "Sedan", VinNo = "XTY10923RD76", IsActive = true},
                new DAL.Entities.Vehicle { CompanyId = "2", CompanyName = "Moq Company", CarNo = "Moq-002", Year = "2011", Make = "Lincoln", Model = "Town Car", Color = "Black", MaxNoOfPassengers = 4, VehicleType = "Sedan", VinNo = "XTY10923RA49", IsActive = true},
                new DAL.Entities.Vehicle { CompanyId = "2", CompanyName = "Moq Company", CarNo = "Moq-101", Year = "2011", Make = "Lincoln", Model = "MKZ", Color = "Black", MaxNoOfPassengers = 6, VehicleType = "SUV", VinNo = "XTY109RHT7I9", IsActive = true},
            };

            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository
                .Setup(x => x.GetVehicle(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string company, string carno) => vehicleDatabase.Where(vd => string.Compare(vd.CompanyName, company, true) == 0 && string.Compare(vd.CarNo, carno, true) == 0).FirstOrDefault());

            var moqVehicleRepository = vehicleRepository.Object;

            DAL.Entities.Vehicle expectedVehicle = new DAL.Entities.Vehicle
            {
                CompanyId = "2",
                CompanyName = "Moq Company",
                CarNo = "Moq-001",
                Year = "2011",
                Make = "Lincoln",
                Model = "Town Car",
                Color = "Black",
                VehicleType = "Sedan",
                MaxNoOfPassengers = 4,
                VinNo = "XTY10923RD76",
                IsActive = true
            };

            var vehicle = moqVehicleRepository.GetVehicle("Moq Company", "Moq-001");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(expectedVehicle.CompanyName, vehicle.CompanyName);
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
                new DAL.Entities.Vehicle { CompanyId = "2", CompanyName = "Moq Company", CarNo = "Moq-001", Year = "2011", Make = "Lincoln", Model = "Town Car", Color = "Black", MaxNoOfPassengers = 4, VehicleType = "Sedan", VinNo = "XTY10923RD76", IsActive = true},
                new DAL.Entities.Vehicle { CompanyId = "2", CompanyName = "Moq Company", CarNo = "Moq-002", Year = "2011", Make = "Lincoln", Model = "Town Car", Color = "Black", MaxNoOfPassengers = 4, VehicleType = "Sedan", VinNo = "XTY10923RA49", IsActive = true},
                new DAL.Entities.Vehicle { CompanyId = "2", CompanyName = "Moq Company", CarNo = "Moq-101", Year = "2011", Make = "Lincoln", Model = "MKZ", Color = "Black", MaxNoOfPassengers = 6, VehicleType = "SUV", VinNo = "XTY109RHT7I9", IsActive = true},
            };

            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository
                .Setup(x => x.GetVehicle(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string company, string carno) => vehicleDatabase.Where(vd => string.Compare(vd.CompanyName, company, true) == 0 && string.Compare(vd.CarNo, carno, true) == 0).FirstOrDefault());

            var vehicleService = new VehicleService(vehicleRepository.Object);

            Domain.Vehicle expectedVehicle = Domain.Vehicle.Create("2", "Moq Company", "Moq-001", "2011", "Lincoln", "Town Car", "Black", "Sedan", 4, "XTY10923RD76", true);
            Domain.Vehicle vehicle = vehicleService.GetVehicle("Moq Company", "Moq-001");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(expectedVehicle.CompanyId, vehicle.CompanyId);
            Assert.AreEqual(expectedVehicle.CarNo, vehicle.CarNo);
            Assert.AreEqual(expectedVehicle.VehicleType, vehicle.VehicleType);
            Assert.AreEqual(expectedVehicle.MaxNoOfPassengers, vehicle.MaxNoOfPassengers);
            Assert.AreEqual(expectedVehicle.IsActive, vehicle.IsActive);
        }
    }
}
