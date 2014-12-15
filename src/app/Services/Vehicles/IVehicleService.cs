using Domain;

namespace Services.Vehicles
{
    public interface IVehicleService
    {
        Vehicle GetVehicle(string provider, string company, string carNo);
    }
}
