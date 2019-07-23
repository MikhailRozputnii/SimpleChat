using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Domains
{
    public class Role : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}