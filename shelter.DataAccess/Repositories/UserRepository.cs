using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.User;

namespace shelter.DataAccess.Repositories;

internal class UserRepository : IUserRepository
{
    private static readonly List<User> users = new List<User>();
    public void Add(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(u => u.Email == email);
    }
}
