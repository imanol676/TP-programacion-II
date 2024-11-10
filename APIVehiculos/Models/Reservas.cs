
public class Reserva
{
    public int Id { get; set; }  // Clave primaria
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Estado { get; set; }  // Estado de la reserva (pendiente, confirmada, cancelada, etc.)

    // Relaciones
    public int VehiculoId { get; set; }  // Clave foránea
    public Vehiculo vehiculo { get; set; }

    public ApplicationUser Usuario { get; set; }


    public bool ValidarReserva()
    {
        // Lógica para validar reserva
        return FechaInicio < FechaFin && !string.IsNullOrEmpty(Estado);
    }
}
