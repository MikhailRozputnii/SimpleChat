using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domains
{
    public class UserRole : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }

        [Required, ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required, ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
