using Microsoft.EntityFrameworkCore;
public class VehiculoDbService : IVehiculoService
{
    private readonly ProjectContext _context;
    public VehiculoDbService(ProjectContext context)
    {
        _context = context;
    }

    public bool ConsultarDisponibilidad(int id)
    {
        throw new NotImplementedException();
    }

    public Vehiculo CreateVehiculo(VehiculoDTO v)
    {
        var nuevoVehiculo = new Vehiculo
        {
            Modelo = v.Modelo,
            Marca = v.Marca,
            PrecioPorDia = (decimal)v.PrecioPorDia,
            EstaDisponible = v.EstaDisponible,
            Reservas = new List<Reserva>()
        };
        _context.Vehiculos.Add(nuevoVehiculo);
        _context.SaveChanges();
        return nuevoVehiculo;
    }

    public void DeleteVehiculo(int id)
    {

    }

    public IEnumerable<Vehiculo> GetAllVehiculos()
    {
        throw new NotImplementedException();
    }

    public Vehiculo? GetVehiculoById(int id)
    {
        throw new NotImplementedException();
    }

    public Vehiculo? UpdateVehiculo(int id, Vehiculo vehiculo)
    {
        throw new NotImplementedException();
    }
}
