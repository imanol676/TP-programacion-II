

public abstract class User //Esta clase  no se instancia para que de ella salgan los roles de cliente y administrador
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Relación con Reservas (Un Usuario puede tener muchas Reservas)
    public List<Reserva> Reservas { get; set; }
}

public class Admin : User
{
    public void GestionarVehiculos()
    {
        // Lógica para gestionar vehículos
    }

    public void GestionarReservas()
    {
        // Lógica para gestionar reservas
    }
}



public class cliente : User
{
    public void RealizarReserva(Reserva reserva)
    {
        // Lógica para realizar una reserva
    }

    public IEnumerable<Reserva> VerHistorialReservas()
    {
        // Lógica para ver el historial de reservas
        return new List<Reserva>();
    }
}

