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
    public class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(c => c.Books)
                   .WithOne(b => b.Category)
                   .HasForeignKey(b => b.CategoryID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new BookCategory { ID = 1, Name = "Science Fiction" },
                new BookCategory { ID = 2, Name = "Mystery" },
                new BookCategory { ID = 3, Name = "Fantasy" },
                new BookCategory { ID = 4, Name = "Romance" },
                new BookCategory { ID = 5, Name = "Biography" },
                new BookCategory { ID = 6, Name = "History" }
            );
        }
    }
}
