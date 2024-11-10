public interface IVehiculoService
{
    IEnumerable<Vehiculo> GetAllVehiculos();
    Vehiculo? GetVehiculoById(int id);
    Vehiculo CreateVehiculo(VehiculoDTO vehiculoDto);
    Vehiculo? UpdateVehiculo(int id, Vehiculo vehiculo);
    void DeleteVehiculo(int id);
    bool ConsultarDisponibilidad(int id);
}