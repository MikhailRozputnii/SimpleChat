using ChatApp.DataAccess.Contracts;
using System;

namespace ChatApp.DataAccess.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ChatAppDbContext _dbContext;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private bool _disposed = false;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);
                return _userRepository;
            }
        }
       
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_dbContext);
                return _roleRepository;
            }
        }
        
        public RepositoryWrapper(ChatAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }    
    }
}
