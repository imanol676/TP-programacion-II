
public class Reserva
{
    public int ReservaId { get; set; }  // Clave primaria
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public required string Estado { get; set; }  // Estado de la reserva (pendiente, confirmada, cancelada, etc.)

    // Relaciones
    public int VehiculoId { get; set; }
    public Vehiculo Vehiculo { get; set; }

    public ApplicationUser Usuario { get; set; }
    public string? UsuarioId { get; internal set; }


    // Constructor
    public Reserva() { }

    public Reserva(DateTime fechaInicio, DateTime fechaFin, string estado, int vehiculoId, ApplicationUser usuario)
    {
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        Estado = estado;
        VehiculoId = vehiculoId;
        Usuario = usuario;
        UsuarioId = usuario?.Id;
    }
}
