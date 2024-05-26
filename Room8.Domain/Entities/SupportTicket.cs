namespace Room8.Domain.Entities
{
    public class SupportTicket
    {
        public int SupportTicketId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public string Status { get; set; } // Open, In Progress, Resolved
    }
}