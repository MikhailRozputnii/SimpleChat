using System;

namespace ChatApp.Domains
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreateDate { get; set; }
    }
}
