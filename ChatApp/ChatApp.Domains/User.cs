using System;

namespace ChatApp.Domains
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public Role Role { get; set; }
    }
}
