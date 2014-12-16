namespace Domain.Api.Vehicles
{
    public interface IVehicleApi
    {
        Vehicle GetVehicle(string company, string carNo);
    }
}
