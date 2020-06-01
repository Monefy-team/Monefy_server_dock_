using System;
using Microsoft.AspNetCore.Identity;
using WebAPI.DAL.EF;
using WebAPI.DAL.Entities;
using WebAPI.DAL.Interfaces;

namespace WebAPI.DAL.EFRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MonefyContext _context;
        private IRepository<Finance> _finances;
        private bool _disposed;

        public UnitOfWork(MonefyContext context,UserManager<User> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        public IRepository<Finance> Finances
        {
            get
            {
                if (_finances == null)
                    _finances = new Repository<Finance>(_context);
                return _finances;
            }
        }
        

        public UserManager<User> UserManager { get; }
        #region Disposing

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}