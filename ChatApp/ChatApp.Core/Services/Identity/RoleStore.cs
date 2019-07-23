using AutoMapper;
using ChatApp.Core.Dto;
using ChatApp.DataAccess.Contracts;
using ChatApp.Domains;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Core.Services.Identity
{
    public class RoleStore : IRoleStore<RoleDto>
    {
        private IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public RoleStore(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IdentityResult> CreateAsync(RoleDto role, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            var entity = _mapper.Map<Role>(role);
            await Task.Run(() => _repository.RoleRepository.Create(entity));
            _repository.Save();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(RoleDto role, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            var entity = _mapper.Map<Role>(role);
            _repository.RoleRepository.Delete(entity);
            await Task.Run(() => _repository.RoleRepository.Delete(entity));
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository?.Dispose();
            }
        }

        public async Task<RoleDto> FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (roleId == null)
                throw new ArgumentNullException(nameof(roleId));
            Guid idGuid;
            if (!Guid.TryParse(roleId, out idGuid))
                throw new ArgumentException("Not a valid Guid id", nameof(roleId));
            var entity = await Task.Run(() => _repository.RoleRepository.GetByCondition(i => i.Id == idGuid));
            var roleDto = _mapper.Map<RoleDto>(entity);
            return roleDto;
        }

        public async Task<RoleDto> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (normalizedRoleName == null)
                throw new ArgumentNullException(nameof(normalizedRoleName));
            var entity = await Task.Run(() => _repository.RoleRepository.GetByCondition(i => i.Name == normalizedRoleName));
            var roleDto = _mapper.Map<RoleDto>(entity);
            return roleDto;
        }

        public Task<string> GetNormalizedRoleNameAsync(RoleDto role, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            return Task.FromResult(role.Name);
        }

        public Task<string> GetRoleIdAsync(RoleDto role, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(RoleDto role, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(RoleDto role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            else if (normalizedName == null)
                throw new ArgumentNullException(nameof(normalizedName));
            role.Name = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetRoleNameAsync(RoleDto role, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            else if (roleName == null)
                role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(RoleDto role, CancellationToken cancellationToken=default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            var entity = await Task.Run(() => _repository.RoleRepository.GetByCondition(i => i.Id == role.Id));
            if (entity == null)
                return IdentityResult.Failed(new IdentityError { Description = $"Could not update role {role.Name}." });

            entity.Name = role.Name;
            await Task.Run(() => _repository.RoleRepository.Update(entity));
            _repository.Save();
            return IdentityResult.Success;
        }
    }
}
