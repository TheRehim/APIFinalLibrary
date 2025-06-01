using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.ID);
            builder.Property(b => b.ID)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Price)
                   .IsRequired()
                   .HasPrecision(10, 2);

            builder.Property(b => b.ISBN)
                   .IsRequired()
                   .HasMaxLength(13);

            builder.Property(b => b.Count)
                   .IsRequired();

            builder.Property(b => b.PicturePath)
                   .IsRequired(false)
                   .HasMaxLength(250);

            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Category)
                   .WithMany(c => c.Books)
                   .HasForeignKey(b => b.CategoryID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
               new Book { ID = 1, Title = "Echoes of Tomorrow", Price = 37.43m, ISBN = "9780316939808", AuthorID = 9, CategoryID = 2, Count = 12, IsActive = true, PicturePath = "default1.jpg", PublishDate = new DateOnly(2022, 3, 15) },
               new Book { ID = 2, Title = "The Silent Archive", Price = 33.71m, ISBN = "9780316376110", AuthorID = 9, CategoryID = 4, Count = 9, IsActive = true, PicturePath = "default2.jpg", PublishDate = new DateOnly(2021, 7, 10) },
               new Book { ID = 3, Title = "Oblivion's Gate", Price = 43.08m, ISBN = "9780316795845", AuthorID = 6, CategoryID = 1, Count = 7, IsActive = true, PicturePath = "default3.jpg", PublishDate = new DateOnly(2020, 11, 5) },
               new Book { ID = 4, Title = "Neon Exodus", Price = 39.70m, ISBN = "9780316113284", AuthorID = 5, CategoryID = 6, Count = 8, IsActive = true, PicturePath = "default4.jpg", PublishDate = new DateOnly(2019, 4, 22) },
               new Book { ID = 5, Title = "Quantum Ashes", Price = 36.57m, ISBN = "9780316923925", AuthorID = 9, CategoryID = 5, Count = 15, IsActive = true, PicturePath = "default5.jpg", PublishDate = new DateOnly(2023, 1, 12) }
           );
        }
    }
}
