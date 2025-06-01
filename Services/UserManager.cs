using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserManager(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = _userManager.Users.ToList();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(string id, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(string id, UserForUpdateDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            user.Email = dto.Email;
            user.Initials = dto.Initials;

            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);
        }

        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return result.Succeeded;
        }
    }
}
