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
    public partial class UserStore : IUserStore<UserDto>
    {
        private IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public UserStore(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
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

        public async Task<IdentityResult> CreateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var entity = _mapper.Map<User>(userDto);
            await Task.Run(() => _repository.UserRepository.Create(entity));
            _repository.Save();
            var isExists = await Task.Run(() => _repository.UserRepository.GetByCondition(i => i.Email == userDto.Email) != null);
            if (!isExists)
                return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {userDto.Email}." });

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var entity = await Task.Run(() => _repository.UserRepository.GetByCondition(i => i.Id == userDto.Id));
            if (entity == null)
                IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {userDto.Email}." });

            entity.IsDeleted = true;
            await Task.Run(() => _repository.UserRepository.Update(entity));
            _repository.Save();
            return IdentityResult.Success;
        }

        public async Task<UserDto> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            Guid idGuid;
            if (!Guid.TryParse(userId, out idGuid))
                throw new ArgumentException("Not a valid Guid id", nameof(userId));

            var entity = await Task.Run(() => _repository.UserRepository.GetByCondition(i => i.Id == idGuid));
            var userDto = _mapper.Map<UserDto>(entity);

            return userDto;
        }

        public async Task<UserDto> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null)
                throw new ArgumentNullException(nameof(userName));

            var entity = await Task.Run(() => _repository.UserRepository.GetByCondition(i => i.Email == userName));
            var userDto = _mapper.Map<UserDto>(entity);
            return userDto;
        }

        public Task<string> GetNormalizedUserNameAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            return Task.FromResult(userDto.NormalizedEmail);
        }

        public Task<string> GetUserIdAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            return Task.FromResult(userDto.Id.ToString());
        }

        public Task<string> GetUserNameAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            return Task.FromResult(userDto.Email);
        }

        public Task SetNormalizedUserNameAsync(UserDto userDto, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));
            else if (normalizedName == null)
                throw new ArgumentNullException(nameof(normalizedName));

            userDto.NormalizedEmail = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(UserDto userDto, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            userDto.Email = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var entity = await Task.Run(() => _repository.UserRepository.GetByCondition(i => i.Id == userDto.Id));
            if (entity == null)
                return IdentityResult.Failed(new IdentityError { Description = $"Could not update user {userDto.Email}." });

            entity.FirstName = userDto.FirstName;
            entity.LastName = userDto.LastName;
            entity.Email = userDto.Email;
            entity.PasswordHash = userDto.PasswordHash;
            await Task.Run(() => _repository.UserRepository.Update(entity));
            _repository.Save();
            return IdentityResult.Success;
        }
    }
}
