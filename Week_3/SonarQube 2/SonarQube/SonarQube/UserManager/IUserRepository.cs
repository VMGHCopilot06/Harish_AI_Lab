public interface IUserRepository
{
    void AddUser(string user);
    void RemoveUser(string user);
    List<string> GetAllUsers();
}

public class UserRepository : IUserRepository
{
    private List<string> users = new List<string>();

    public void AddUser(string user)
    {
        users.Add(user);
    }

    public void RemoveUser(string user)
    {
        users.Remove(user);
    }

    public List<string> GetAllUsers()
    {
        return new List<string>(users);
    }
}
