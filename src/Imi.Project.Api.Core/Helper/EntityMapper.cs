
using Imi.Project.Api.Core.Dtos.Birds;
using Imi.Project.Api.Core.Dtos.Cages;
using Imi.Project.Api.Core.Dtos.DailyTasks;
using Imi.Project.Api.Core.Dtos.Medicines;
using Imi.Project.Api.Core.Dtos.Species;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Helper
{
    public static class EntityMapper
    {
        public static User MapToEntity(this UserRequestDto userDto)
        {
           var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name
            };
            return user;
        }
    
        public static Bird MapToEntity(this BirdRequestDto birdDto)
        {
            var bird = new Bird
            {
                Id = birdDto.Id,
                Name = birdDto.Name,
                CageId = birdDto.CageId,
                Gender = birdDto.Gender,
                Food = birdDto.Food,
                Image = birdDto.Image,
                HatchDate = birdDto.HatchDate,
                SpeciesId = birdDto.SpeciesId,
                UserId = birdDto.UserId
            };
            return bird;

        }

        public static Cage MapToEntity(this CageRequestDto cageDto)
        {
            var cage = new Cage
            {
                Id = cageDto.Id,
                Name = cageDto.Name,
                Location = cageDto.Location,
                Image = cageDto.Image,
                UserId = cageDto.UserId
            };
            return cage;
        }

        public static Medicine MapToEntity(this MedicineRequestDto medicineDto)
        {
            var medicine = new Medicine
            {
                Id = medicineDto.Id,
                Name = medicineDto.Name,
                Usage = medicineDto.Usage,
                UserId = medicineDto.UserId
            };
            return medicine;
        }

        public static DailyTask MapToEntity(this DailyTaskRequestDto taskDto)
        {
            var task = new DailyTask
            {
                Id = taskDto.Id,
                Name = taskDto.Name,
                CageId = taskDto.CageId,
                IsDone = taskDto.IsDone
            };
            return task;
        }

        public static Species MapToEntity(this SpeciesRequestDto speciesDto)
        {
            var species = new Species
            {
                Id = speciesDto.Id,
                Name = speciesDto.Name,
                ScientificName = speciesDto.ScientificName

            };
            return species;
        }
    }
}
