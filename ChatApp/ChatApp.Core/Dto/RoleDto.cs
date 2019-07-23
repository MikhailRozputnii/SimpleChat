using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Core.Dto
{
    public class RoleDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }
    }
}
