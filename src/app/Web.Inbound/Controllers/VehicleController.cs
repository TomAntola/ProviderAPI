using Domain;
using Domain.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Inbound.Controllers
{
    public class VehicleController : ApiController
    {
        private VehicleService _vehicleService = null;

        public VehicleController()
        {
            var _vehicleService = new VehicleService();
        }

        public HttpResponseMessage Get(HttpRequestMessage request, string provider, string company, string carNo)
        {
            _vehicleService = new VehicleService();
            var vehicle = _vehicleService.GetVehicle(provider, company, carNo);

            return request.CreateResponse<Vehicle>(HttpStatusCode.OK, vehicle);
        }
    }
}
