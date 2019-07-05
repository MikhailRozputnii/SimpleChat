using System.Threading;
using System.Threading.Tasks;
using ChatApp.Core.Dto;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Core.Services.Identity
{
    internal class RoleStore : IRoleStore<UserRoleDto>
    {
        public Task<IdentityResult> CreateAsync(UserRoleDto role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserRoleDto role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<UserRoleDto> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRoleDto> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(UserRoleDto role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(UserRoleDto role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(UserRoleDto role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(UserRoleDto role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetRoleNameAsync(UserRoleDto role, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserRoleDto role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
