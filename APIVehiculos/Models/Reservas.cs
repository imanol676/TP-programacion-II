
public class Reserva
{
    public int IdReserva { get; set; }  // Clave primaria
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public required string Estado { get; set; }  // Estado de la reserva (pendiente, confirmada, cancelada, etc.)

    // Relaciones
    public int VehiculoId { get; set; }  // Clave foránea
    public required Vehiculo vehiculo { get; set; }

    public required ApplicationUser Usuario { get; set; }
    public int UserId { get; internal set; }

    public bool ValidarReserva()
    {
        // Lógica para validar reserva
        return FechaInicio < FechaFin && !string.IsNullOrEmpty(Estado);
    }
}
