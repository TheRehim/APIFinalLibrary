using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync(bool trackChanges);
        Task<Notification> GetNotificationAsync(int id, bool trackChanges);
        void CreateNotification(Notification notification);
        void DeleteNotification(Notification notification);
    }
}
