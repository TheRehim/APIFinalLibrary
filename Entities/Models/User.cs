using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }

        public virtual ICollection<BookBorrowRequest> BorrowRequests { get; set; } = new HashSet<BookBorrowRequest>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public virtual ICollection<LogEntry> Logs { get; set; } = new List<LogEntry>();

    }
}
