﻿using OmiconShop.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        User GetUserById(int id);

        Task<User> ChangeUserEmailAsync(int id, string email);

        Task UpdateUserAsync(string email, Action<User> user);
    }
}
