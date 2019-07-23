using System;

namespace ChatApp.DataAccess.Contracts
{
    public interface IRepositoryWrapper : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        void Save();
    }
}
