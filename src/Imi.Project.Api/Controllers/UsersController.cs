using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Common;
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
        protected readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.ListAllAsync();
            var usersDto = users.Select(u =>
            new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Cages = u.Cages.Select(b =>
                new CageResponseDto
                {
                    Id = b.Id,
                    DailyTasks = b.DailyTasks.Select(b =>
                new DailyTaskResponseDto
                {
                    Id = b.Id,

                }).ToList(),
                Birds = b.Birds.Select(b =>
                new BirdResponseDto
                {
                    Id = b.Id,

                }).ToList(),
                }).ToList(),
                Birds = u.Birds.Select(b =>
                new BirdResponseDto
                {
                    Id = b.Id,

                }).ToList(),
                Medicines = u.Medicines.Select(b =>
                new MedicineResponseDto
                {
                    Id = b.Id,

                }).ToList()


            }) ;

            return Ok(usersDto);

        }
    }
}
