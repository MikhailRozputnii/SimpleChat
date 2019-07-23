﻿using System;

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

        public RoleDto Role { get; set; }
    }
}
