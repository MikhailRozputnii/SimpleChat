using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domains
{
    public class Friend : IEntity
    {

        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? FriendId { get; set; }
        public DateTime CreateDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("FriendId")]
        public User UserFriend { get; set; }
    }
}
