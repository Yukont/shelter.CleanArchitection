using shelter.Domain.User;

namespace shelter.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email); 
    void Add(User user);
}
