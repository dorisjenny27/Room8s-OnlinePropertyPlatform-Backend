namespace Room8.Domain.Entities
{
    public class Message : IAuditable
    {
        public long SenderId { get; set; }
        //public User Sender { get; set; }
        public long ReceiverId { get; set; }
        //public User Receiver { get; set; }
        public string MessageBody { get; set; }

        public bool IsRead { get; set; }    
        public bool IsDeleted { get; set; }
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
 
}
