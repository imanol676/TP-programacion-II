using Microsoft.EntityFrameworkCore;

public class ReservaDbService : IReservaService
{
    private readonly ProjectContext _context;

    public ReservaDbService(ProjectContext context)
    {
        _context = context;
    }
    public Reserva CreateReserva(ReservaDTO r)
    {
        Reserva reserva = new()
        {
            FechaInicio = r.FechaInicio,
            FechaFin = r.FechaFin,
            Estado = r.Estado,
            VehiculoId = r.VehiculoId,
            UserId = r.UserId,
        };
        _context.Reservas.Add(reserva);
        _context.SaveChanges();
        return reserva;
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

    public IEnumerable<Reserva> GetReservasByUserId(int userId)
    {
        return _context.Reservas.Where(r => r.UserId == userId).ToList();
    }
    }