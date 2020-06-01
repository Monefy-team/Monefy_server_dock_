using System;
using Microsoft.AspNetCore.Identity;
using WebAPI.DAL.Entities;

namespace WebAPI.DAL.Interfaces
{
    // Единица работа
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Finance> Finances { get; }
        public UserManager<User> UserManager { get; }
    }
}