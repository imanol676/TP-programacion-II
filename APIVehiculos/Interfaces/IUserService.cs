public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);
    User Create(UserDTO userDto);
    void DeleteUser(int id);
    User? UpdateUser(int id, User user);

}

public interface IAdministrador : IUserService
{
    void GestionarVehiculos();
    void GestionarReservas();
}

public interface ICliente : IUserService
{
    void RealizarReserva(Reserva reserva);
    IEnumerable<Reserva> VerHistorialReservas();
}