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
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                   .ValueGeneratedOnAdd(); // auto increment

            builder.Property(a => a.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(a => a.Books)
                   .WithOne(b => b.Author)
                   .HasForeignKey(b => b.AuthorID)
                   .OnDelete(DeleteBehavior.Restrict); // do not delete books when author is deleted

            builder.HasData(
                new Author { ID = 1, FullName = "Isaac Newton" },
                new Author { ID = 2, FullName = "Clara Hastings" },
                new Author { ID = 3, FullName = "Jules Verne" },
                new Author { ID = 4, FullName = "Nina Patel" },
                new Author { ID = 5, FullName = "Haruki Murakami" },
                new Author { ID = 6, FullName = "Liam Gallagher" },
                new Author { ID = 7, FullName = "Tariq Ahmad" },
                new Author { ID = 8, FullName = "Elena Wood" },
                new Author { ID = 9, FullName = "Arthur Greene" },
                new Author { ID = 10, FullName = "Zara Bennett" }
            );
        }
    }
}
