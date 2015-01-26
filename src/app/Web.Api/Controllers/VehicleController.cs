using Domain.Api.Vehicles;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Api.Representations;

namespace Web.Api.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleApi _vehicleApi;

        public VehicleController(IVehicleApi VehicleApi)
        {
            _vehicleApi = VehicleApi;
        }

        public HttpResponseMessage Get(HttpRequestMessage request, int provider_id, string company_name, string carNo)
        {
            var domain_vehicle = _vehicleApi.GetVehicle(provider_id, company_name, carNo);
            var vehicle_representation = new Vehicle(domain_vehicle);

            return request.CreateResponse<Vehicle>(HttpStatusCode.OK, vehicle_representation);
        }
    }
}
