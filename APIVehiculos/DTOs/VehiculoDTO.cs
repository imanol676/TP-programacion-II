using System.ComponentModel.DataAnnotations;
public class VehiculoDTO
{
    [Required(ErrorMessage = "El campo Modelo es requerido.")]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "El campo Marca es requerido.")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "El campo es requerido.")]
    public float PrecioPorDia { get; set; }

    [Required(ErrorMessage = "El campo es requerido.")]
    public string EstaDisponible { get; set; }
}