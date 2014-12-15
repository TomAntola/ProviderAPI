using Domain;

namespace Services
{
    public interface IVehicleService
    {
        Vehicle GetVehicle(string provider, string company, string carNo);
    }
}
