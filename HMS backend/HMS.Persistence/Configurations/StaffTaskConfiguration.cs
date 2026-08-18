using HMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HMS.Persistence.Configurations
{
    public class StaffTaskConfiguration : IEntityTypeConfiguration<StaffTask>
    {
        public void Configure(EntityTypeBuilder<StaffTask> builder)
        {
            // Primary Key
            builder.HasKey(x => x.StaffTaskId);

            // Title
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            // Description
            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            // Status
            builder.Property(x => x.Status)
                   .IsRequired();

            // Assigned Date
            builder.Property(x => x.AssignedDate)
                   .IsRequired();

            // Staff Relationship
            builder.HasOne(x => x.Staff)
                   .WithMany()
                   .HasForeignKey(x => x.StaffId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AssignedByUser)
       .WithMany()
       .HasForeignKey(x => x.AssignedByUserId)
       .OnDelete(DeleteBehavior.Restrict);

            // Room Relationship
            builder.HasOne(x => x.Room)
                   .WithMany()
                   .HasForeignKey(x => x.RoomId)
                   .OnDelete(DeleteBehavior.SetNull);

           
        }


    }
}