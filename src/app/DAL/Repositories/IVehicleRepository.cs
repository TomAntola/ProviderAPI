using DAL.Entities;

namespace DAL.Repositories
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicle(string provider, string company, string carNo);
    }
}
