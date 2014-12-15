using DAL.Entities;

namespace DAL.Repositories
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicle(string company, string carNo);
    }
}
