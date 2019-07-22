using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Core.Dto
{
    public class UserRoleDto
    {
        public Guid Id { get; set; }
        public  RoleDto Role { get; set; }
        public  UserDto User { get; set; }
    }
}
