using Domain;

namespace Services.Vehicles
{
    public interface IVehicleService
    {
        Vehicle GetVehicle(string company, string carNo);
    }
}
