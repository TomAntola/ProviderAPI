using Domain;
using Domain.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Inbound.Controllers
{
    public class VehicleController : ApiController
    {
        private IVehicleService _vehicleService;

        public VehicleController()
        {
            _vehicleService = new VehicleService();
        }

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public HttpResponseMessage Get(HttpRequestMessage request, string provider, string company, string carNo)
        {
            var vehicle = _vehicleService.GetVehicle(provider, company, carNo);

            return request.CreateResponse<Vehicle>(HttpStatusCode.OK, vehicle);
        }
    }
}
