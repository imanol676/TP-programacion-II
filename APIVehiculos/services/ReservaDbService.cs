using Microsoft.EntityFrameworkCore;

public class ReservaDbService : IReservaService
{
    private readonly ProjectContext _context;
    private readonly ApplicationDbContext _usercontext;

    public ReservaDbService(ProjectContext context, ApplicationDbContext usercontext)
    {
        _context = context;
        _usercontext = usercontext;
    }

    public Reserva CreateReserva(ReservaDTO r)
    {
        var usuario = _usercontext.Users.FirstOrDefault(x => x.UserName == r.UserId);
        var vehiculo = _context.Vehiculos.Find(r.VehiculoId);

        if (usuario == null || vehiculo == null)
        {
            var missingEntity = usuario == null ? "Usuario" : "Vehículo";
            var missingId = usuario == null ? r.UserId : r.VehiculoId.ToString();
            throw new Exception($"{missingEntity} no encontrado con ID: {missingId}");
        }

        var nuevaReserva = new Reserva
        {
            FechaInicio = r.FechaInicio,
            FechaFin = r.FechaFin,
            Estado = r.Estado,
            Usuario = usuario,
            UsuarioId = usuario.Id,
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
        // Incluye los datos del Usuario y Vehículo relacionados en las Reservas
        return _context.Reservas
            .Include(r => r.Usuario)
            .Include(r => r.Vehiculo)
            .ToList();
    }

    public Reserva? GetReservaById(int id)
    {
        // Incluye los datos del Usuario y Vehículo para una reserva específica
        return _context.Reservas
            .Include(r => r.Usuario)
            .Include(r => r.Vehiculo)
            .FirstOrDefault(r => r.ReservaId == id);
    }

    public Reserva? UpdateReserva(int id, Reserva r)
    {
        _context.Entry(r).State = EntityState.Modified;
        _context.SaveChanges();
        return r;
    }

    public IEnumerable<Reserva> GetReservasByUserId(string userId)
    {
        return _context.Reservas
            .Where(r => r.UsuarioId == userId)
            .Include(r => r.Vehiculo)
            .ToList();
    }

    public ReservaDTO CreateReserva(string userName)
    {
        throw new NotImplementedException();
    }
}