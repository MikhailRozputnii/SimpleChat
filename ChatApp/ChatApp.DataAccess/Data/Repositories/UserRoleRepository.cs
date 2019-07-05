using ChatApp.DataAccess.Contracts;
using ChatApp.Domains;

namespace ChatApp.DataAccess.Data.Repositories
{
    internal class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ChatAppDbContext dbContext):base(dbContext)
        {
        }
    }
}
