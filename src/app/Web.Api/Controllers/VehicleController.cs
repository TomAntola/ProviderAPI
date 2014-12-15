using Services.Vehicles;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Api.Representations;

namespace Web.Api.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public HttpResponseMessage Get(HttpRequestMessage request, string company, string carNo)
        {
            var domain_vehicle = _vehicleService.GetVehicle(company, carNo);
            var vehicle_representation = new Vehicle(domain_vehicle);

            return request.CreateResponse<Vehicle>(HttpStatusCode.OK, vehicle_representation);
        }
    }
}
