namespace Room8.Domain.Entities
{
    public class RentShare
    {
        public int RentShareId { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal RentAmount { get; set; }
    }
}
