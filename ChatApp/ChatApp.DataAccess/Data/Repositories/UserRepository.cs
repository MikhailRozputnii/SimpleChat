using ChatApp.DataAccess.Contracts;
using ChatApp.Domains;

namespace ChatApp.DataAccess.Data.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ChatAppDbContext dbContext) : base(dbContext) { }
    }
}
