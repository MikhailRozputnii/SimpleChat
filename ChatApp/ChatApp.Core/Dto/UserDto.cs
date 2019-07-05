using System;
using System.Collections.Generic;

namespace ChatApp.Core.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
