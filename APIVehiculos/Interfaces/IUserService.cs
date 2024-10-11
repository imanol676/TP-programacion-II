public interface IUserService
{
    public IEnumerable<User> getAll();
    User GetUserById(int id);
    // public User Create(UserDTO user);

}