using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Primary Key
            builder.HasKey(x => x.RoomId);

            // Room Number
            builder.Property(x => x.RoomNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            // Unique Room Number
            builder.HasIndex(x => x.RoomNumber)
                   .IsUnique();

            // Floor
            builder.Property(x => x.Floor)
                   .HasMaxLength(50);

         

            // Description
            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            // Room Status
            builder.Property(x => x.Status)
                   .IsRequired();

            // Relationship
            builder.HasOne(x => x.RoomType)
                   .WithMany(x => x.Rooms)
                   .HasForeignKey(x => x.RoomTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.PricePerNight)
       .HasPrecision(18, 2)
       .IsRequired();
        }
    }
}
