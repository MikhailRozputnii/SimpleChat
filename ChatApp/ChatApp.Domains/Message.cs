using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domains
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }

        
        public Guid? SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
    }
}
