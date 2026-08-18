using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            // Primary Key
            builder.HasKey(x => x.BookingId);

            // Booking Status
            builder.Property(x => x.Status)
                   .IsRequired();

            // Check-In Date
            builder.Property(x => x.CheckInDate)
                   .IsRequired();

            // Check-Out Date
            builder.Property(x => x.CheckOutDate)
                   .IsRequired();

            // Booking Date
            builder.Property(x => x.BookingDate)
                   .IsRequired();

            // Customer Relationship
            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Room Relationship
            builder.HasOne(x => x.Room)
                   .WithMany(r => r.Bookings)
                   .HasForeignKey(x => x.RoomId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Accepted By User
            builder.HasOne(x => x.AcceptedByUser)
                   .WithMany()
                   .HasForeignKey(x => x.AcceptedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}