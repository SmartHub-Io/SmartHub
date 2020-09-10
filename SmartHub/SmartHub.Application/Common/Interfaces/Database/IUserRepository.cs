﻿using System.Threading.Tasks;
using SmartHub.Domain.Entities;

namespace SmartHub.Application.Common.Interfaces.Database
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user, string pw, string roleName);
        Task<bool> UserChangeRole(User user, string newRoleName);
        Task<User> GetUserByName(string username);
    }
}