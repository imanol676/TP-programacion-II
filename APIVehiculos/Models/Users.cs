

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

}

public class Client : User
{

}