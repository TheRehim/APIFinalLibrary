using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges);
        Task<UserDto> GetUserByIdAsync(string id, bool trackChanges);
        Task UpdateUserAsync(string id, UserForUpdateDto dto);
        Task DeleteUserAsync(string id);
        Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    }
}
