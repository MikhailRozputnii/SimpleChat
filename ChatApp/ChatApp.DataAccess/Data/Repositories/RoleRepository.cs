using ChatApp.DataAccess.Contracts;
using ChatApp.Domains;

namespace ChatApp.DataAccess.Data.Repositories
{
    internal class RoleRepository:BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ChatAppDbContext dbContext) :base(dbContext){ }
    }
}
