public interface IReservaService
{
    IEnumerable<Reserva> GetAllReservas();
    Reserva? GetReservaById(int id);
    Reserva CreateReserva(ReservaDTO reservaDto);
    Reserva? UpdateReserva(int id, Reserva reserva);
    void DeleteReserva(int id);
    bool ValidarReserva(int id);
    IEnumerable<Reserva> GetReservasByUserId(int userId);
}