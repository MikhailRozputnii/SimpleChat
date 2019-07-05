using ChatApp.Core.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Core.Services.Identity
{
    internal partial class UserStore : IUserPasswordStore<UserDto>
    {
        public Task<string> GetPasswordHashAsync(UserDto user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(UserDto user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetPasswordHashAsync(UserDto user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (passwordHash == null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }
    }
}
