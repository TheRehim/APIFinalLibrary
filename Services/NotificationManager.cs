using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationManager : INotificationService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public NotificationManager(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync(bool trackChanges)
        {
            var notifs = await _repo.Notification.GetAllNotificationsAsync(trackChanges);
            return _mapper.Map<IEnumerable<NotificationDto>>(notifs);
        }

        public async Task<NotificationDto> GetNotificationByIdAsync(int id, bool trackChanges)
        {
            var notif = await _repo.Notification.GetNotificationAsync(id, trackChanges);
            return _mapper.Map<NotificationDto>(notif);
        }

        public async Task CreateNotificationAsync(NotificationDtoForInsertion dto)
        {
            var notif = _mapper.Map<Notification>(dto);
            _repo.Notification.CreateNotification(notif);
            await _repo.SaveAsync();
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notif = await _repo.Notification.GetNotificationAsync(id, false);
            _repo.Notification.DeleteNotification(notif);
            await _repo.SaveAsync();
        }
    }
}
