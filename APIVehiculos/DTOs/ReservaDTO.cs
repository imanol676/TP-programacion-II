using System.ComponentModel.DataAnnotations;

public class ReservaDTO
{
    [Required(ErrorMessage = "El campo es requerido.")]
    public int VehiculoId { get; set; }

    [Required(ErrorMessage = "El campo es requerido.")]
    public int userId { get; set; }

    [Required(ErrorMessage = "El campo Fecha de inicio es requerido.")]
    public DateTime FechaInicio { get; set; }

    [Required(ErrorMessage = "El campo Fecha de fin es requerido.")]
    public DateTime FechaFin { get; set; }

    [Required(ErrorMessage = "El campo Estado es requerido.")]
    public required string Estado { get; set; }
    public int UserId { get; internal set; }
}