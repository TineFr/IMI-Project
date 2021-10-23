
using Imi.Project.Api.Core.Dtos.Requests;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.ListAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDto = await _userService.AddUserAsync(newUser);
            return Ok(userDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserRequestDto updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDto = await _userService.UpdateUserAsync(updatedUser);
            return Ok(userDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserRequestDto updatedUser)
        {
            if (updatedUser == null)
            {
                return NotFound($"User does not exist");

            }
            await _userService.DeleteUserAsync(updatedUser);
            return Ok();
        }

    }
    
}
