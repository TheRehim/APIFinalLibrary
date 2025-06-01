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
    public class BookBorrowRequestConfig : IEntityTypeConfiguration<BookBorrowRequest>
    {
        public void Configure(EntityTypeBuilder<BookBorrowRequest> builder)
        {
            builder.HasKey(br => br.ID);
            builder.Property(br => br.ID)
                   .ValueGeneratedOnAdd();

            builder.Property(br => br.StartDate).IsRequired();
            builder.Property(br => br.EndDate).IsRequired();
            builder.Property(br => br.DurationDays).IsRequired();

            builder.HasOne(br => br.Book)
                   .WithMany(b => b.BorrowRequests)
                   .HasForeignKey(br => br.BookID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(br => br.User)
                   .WithMany(u => u.BorrowRequests)
                   .HasForeignKey(br => br.UserID)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }

}
