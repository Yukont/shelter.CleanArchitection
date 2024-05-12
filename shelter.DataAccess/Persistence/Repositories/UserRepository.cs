﻿using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.UserAggregate;

namespace shelter.DataAccess.Persistence.Repositories;

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
