using Microsoft.EntityFrameworkCore;

public class ReservaDbService : IReservaService
{
    private readonly ProjectContext _context;
    private readonly ApplicationDbContext _applicationContext;

    public ReservaDbService(ProjectContext context, ApplicationDbContext applicationContext)
    {
        _context = context;
        _applicationContext = applicationContext;
    }
    public Reserva CreateReserva(ReservaDTO r)
    {
        var usuario = _applicationContext.Users.Find(r.UserId);
        var vehiculo = _context.Vehiculos.Find(r.VehiculoId);
        if (usuario == null || vehiculo == null)
        {
            throw new Exception("Usuario o vehículo no encontrado");
        }
        var nuevaReserva = new Reserva
        {
            FechaInicio = r.FechaInicio,
            FechaFin = r.FechaFin,
            Estado = r.Estado,
            Usuario = usuario,
            Vehiculo = vehiculo
        };
        _context.Reservas.Add(nuevaReserva);
        _context.SaveChanges();
        return nuevaReserva;
    }

    public void DeleteReserva(int id)
    {
        var r = _context.Reservas.Find(id);
        if (r != null)
        {
            _context.Reservas.Remove(r);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Reserva> GetAllReservas()
    {
        return _context.Reservas;
    }

    public Reserva? GetReservaById(int id)
    {
        return _context.Reservas.Find(id);
    }

    public Reserva? UpdateReserva(int id, Reserva r)
    {
        _context.Entry(r).State = EntityState.Modified;
        _context.SaveChanges();
        return r;
    }

    public IEnumerable<Reserva> GetReservasByUserId(string userId)
    {
        return _context.Reservas.Where(r => r.UserId == userId);
    }
}