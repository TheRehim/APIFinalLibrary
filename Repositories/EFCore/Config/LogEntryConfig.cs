using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class LogEntryConfig : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {

            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.Action)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Message)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Timestamp)
                   .IsRequired();

            builder.Property(a => a.Details)
                   .IsRequired(false);

            builder.HasOne(a => a.User)
                   .WithMany(u => u.Logs)
                   .HasForeignKey(a => a.UserID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
