namespace Domain.Api.Vehicles
{
    public interface IVehicleApi
    {
        Vehicle GetVehicle(int providerId, string company, string carNo);
    }
}
