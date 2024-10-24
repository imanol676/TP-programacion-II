public class Vehiculo
{
    public int Id { get; set; }  // Clave primaria
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public decimal PrecioPorDia { get; set; }
    public bool EstaDisponible { get; set; }

    // Relación con Reservas (Un Vehiculo puede estar en muchas Reservas)
    public List<Reserva> Reservas { get; set; }


}
