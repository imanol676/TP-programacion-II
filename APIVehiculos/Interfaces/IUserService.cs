public interface IUserService
{
    IEnumerable<ApplicationUser> GetAllUsers();
    ApplicationUser? GetUserById(int id);
    ApplicationUser Create(RegisterDTO userDto);
    void DeleteUser(int id);
    ApplicationUser? UpdateUser(int id, ApplicationUser user);

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