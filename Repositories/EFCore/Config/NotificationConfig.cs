using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.ID);
            builder.Property(n => n.ID)
                   .ValueGeneratedOnAdd();

            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(n => n.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(n => n.User)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(n => n.UserID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
