using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync(bool trackChanges);
        Task<NotificationDto> GetNotificationByIdAsync(int id, bool trackChanges);
        Task CreateNotificationAsync(NotificationDtoForInsertion dto);
        Task DeleteNotificationAsync(int id);
    }
}
