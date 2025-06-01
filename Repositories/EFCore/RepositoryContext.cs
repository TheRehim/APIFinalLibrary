using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowRequest> BookBorrowRequests { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookBorrowRequestConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BookCategoryConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());
            modelBuilder.ApplyConfiguration(new LogEntryConfig());
        }
    }
}
