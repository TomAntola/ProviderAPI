using Domain;
using Domain.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Inbound.Controllers
{
    public class VehicleController : ApiController
    {
        public HttpResponseMessage Get(HttpRequestMessage request, string provider, string company, string carNo)
        {
            var vehicleService = new VehicleService();

            var vehicle = vehicleService.GetVehicle(provider, company, carNo);

            // Map domain model to view model and then return response.
            return request.CreateResponse<Vehicle>(HttpStatusCode.OK, vehicle);
        }
    }
}
