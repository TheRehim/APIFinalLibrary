using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(n => n.User)
                .ToListAsync();

        public async Task<Notification> GetNotificationAsync(int id, bool trackChanges) =>
            await FindByCondition(n => n.ID == id, trackChanges)
                .Include(n => n.User)
                .SingleOrDefaultAsync();

        public void CreateNotification(Notification notification) => Create(notification);
        public void DeleteNotification(Notification notification) => Delete(notification);
    }
}
