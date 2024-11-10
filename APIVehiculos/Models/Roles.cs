

public class Admin : ApplicationUser
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



public class Cliente : ApplicationUser
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

