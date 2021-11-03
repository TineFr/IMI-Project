

using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Helper;
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
        protected readonly ICageService _cageService;
        protected readonly IBirdService _birdService;
        protected readonly IPrescriptionService _prescriptionService;
        protected readonly IMedicineService _medicineService;


        public UsersController(IUserService userService, ICageService cageService, IBirdService birdService, IMedicineService medicineService, IPrescriptionService prescriptionService)
        {
            _userService = userService;
            _cageService = cageService;
            _birdService = birdService;
            _medicineService = medicineService;
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.ListAllUsersAsync();
            var result = users.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var userDto = user.MapToDto();
            return Ok(userDto);
        }

        [HttpGet("{id}/cages")]
        public async Task<IActionResult> GetCagesFromUser(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var cages = await _cageService.GetCagesByUserIdAsync(id);
            var result = cages.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}/birds")]
        public async Task<IActionResult> GetBirdsFromUser(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var birds = await _birdService.GetBirdsByUserIdAsync(id);
            var result = birds.MapToDtoList();
            return Ok(result);
        }
        [HttpGet("{id}/medicines")]
        public async Task<IActionResult> GetMedicinesFromUser(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var medicines = await _medicineService.GetMedicinesByUserIdAsync(id);
            var result = medicines.MapToDtoList();
            return Ok(result);
        }

        [HttpGet("{id}/prescriptions")]
        public async Task<IActionResult> GetPrescriptionsFromUser(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} does not exist");
            }
            var prescriptions = await _prescriptionService.GetPrescriptionsByUserIdAsync(id);
            var result = prescriptions.MapToDtoList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.GetUserByIdAsync(newUser.Id);
            if (user != null)
            {
                return BadRequest($"User with id {newUser.Id} already exists");
            }
            var newUserEntity = newUser.MapToEntity();
            var result = await _userService.AddUserAsync(newUserEntity);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserRequestDto updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.GetUserByIdAsync(updatedUser.Id);
            if (user == null)
            {
                return NotFound($"User with id {updatedUser.Id} does not exist");
            }
            user.Update(updatedUser);
            var result = await _userService.UpdateUserAsync(user);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(UserRequestDto userToDelete)
        {
            var user = await _userService.GetUserByIdAsync(userToDelete.Id);
            if (user == null)
            {
                return NotFound($"User with id {userToDelete.Id} does not exist");
            }
            await _userService.DeleteUserAsync(user);
            return Ok();
        }


    }

}
    

