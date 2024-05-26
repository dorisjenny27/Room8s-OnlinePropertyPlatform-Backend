using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Room8.Domain.Entities;

namespace Room8.Data.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //public DbSet<ProductMetrics> ProductMetrics { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Listing> Listings { get; set; }
        //public DbSet<RentShare> RentShares { get; set; }
        //public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SavedApartment> SavedApartments { get; set; }
        //public DbSet<Tenant> Tenants { get; set; }
        //public DbSet<UserAnalytics> UserAnalytics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Apartment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Category>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Message>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<SavedApartment>()
                .HasKey(a => a.Id);


            // Configure Apartment - Category relationship
            modelBuilder.Entity<Apartment>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Apartments)
                .HasForeignKey(p => p.CategoryId);

            // Configure Property - User (Owner) relationship
            modelBuilder.Entity<Apartment>()
                 .HasOne(p => p.User) 
                 .WithMany(u => u.Apartments)
                 .HasForeignKey(p => p.UserId);

            // Configure Listing - Property relationship
            //modelBuilder.Entity<Listing>()
            //    .HasOne(l => l.Apartment)
            //    .WithMany(p => p.Listings)
            //    .HasForeignKey(l => l.ApartmentId);

            // Configure RentShare - Listing relationship
            //modelBuilder.Entity<RentShare>()
            //    .HasOne(rs => rs.Listing)
            //    .WithMany(l => l.RentShares)
            //    .HasForeignKey(rs => rs.ListingId);

            // Configure RentShare - User relationship
            //modelBuilder.Entity<RentShare>()
            //    .HasOne(rs => rs.User)
            //    .WithMany(u => u.RentShares)
            //    .HasForeignKey(rs => rs.UserId);

            // Configure Message relationships
            //modelBuilder.Entity<Message>()
            //    .HasOne(m => m.Sender)
            //    .WithMany(u => u.SentMessages)
            //    .HasForeignKey(m => m.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Message>()
            //    .HasOne(m => m.Receiver)
            //    .WithMany(u => u.ReceivedMessages)
            //    .HasForeignKey(m => m.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure SavedApartment relationships
            //modelBuilder.Entity<SavedApartment>()
            //    .HasOne(sa => sa.User)
            //    .WithMany(u => u.SavedApartments)
            //    .HasForeignKey(sa => sa.UserId);


            // Configure SupportTicket relationships
            //modelBuilder.Entity<SupportTicket>()
            //    .HasOne(st => st.User)
            //    .WithMany(u => u.SupportTickets)
            //    .HasForeignKey(st => st.UserId);

            // Configure Tenant relationships
            //modelBuilder.Entity<Tenant>()
            //    .HasOne(t => t.User)
            //    .WithMany(u => u.Tenants)
            //    .HasForeignKey(t => t.UserId);
        }
    }
}
