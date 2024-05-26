namespace Room8.Domain.Entities
{
    public class Listing
    {
        public int ListingId { get; set; }
        public decimal Price { get; set; }
        public int NumberOfRooms { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }     
        public List<RentShare> RentShares { get; set; } = new List<RentShare>();
    }
}