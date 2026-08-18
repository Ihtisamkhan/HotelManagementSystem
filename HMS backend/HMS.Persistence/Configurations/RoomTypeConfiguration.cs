using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMS.Persistence.Configurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            // Primary Key
            builder.HasKey(x => x.RoomTypeId);

            // Name
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Description
            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            // One RoomType has many Rooms
            builder.HasMany(x => x.Rooms)
                   .WithOne(x => x.RoomType)
                   .HasForeignKey(x => x.RoomTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
