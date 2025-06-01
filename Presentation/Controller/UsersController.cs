using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<User> _userManager;

        public UsersController(IServiceManager manager, UserManager<User> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _manager.UserService.GetAllUsersAsync(false);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _manager.UserService.GetUserByIdAsync(id, false);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserForUpdateDto dto)
        {
            await _manager.UserService.UpdateUserAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _manager.UserService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return NotFound();

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            return result.Succeeded ? NoContent() : BadRequest(result.Errors);
        }
    }
}
