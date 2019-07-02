using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.DataAccess.Contracts
{
    public interface IRepositoryWrapper:IDisposable
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
