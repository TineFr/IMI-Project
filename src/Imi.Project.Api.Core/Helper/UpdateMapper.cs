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
   public static class UpdateMapper
    {
        public static User Update(this User user, UserRequestDto dto)
        {
            user.Name = dto.Name;
            return user;
        }
        public static Bird Update(this Bird bird, BirdRequestDto birdDto)
        {
            bird.Name = birdDto.Name;
            bird.CageId = birdDto.CageId;
            bird.Gender = birdDto.Gender;
            bird.Food = birdDto.Food;
            bird.Image = birdDto.Image;
            bird.HatchDate = birdDto.HatchDate;
            bird.SpeciesId = birdDto.SpeciesId;
            return bird;
        }
        public static Cage Update(this Cage cage, CageRequestDto cageDto)
        {

            cage.Name = cageDto.Name;
            cage.Location = cageDto.Location;
            //cage.Image = cageDto.Image;

            return cage;
        }

        public static Medicine Update(this Medicine medicine, MedicineRequestDto medicineDto)
        {

            medicine.Name = medicineDto.Name;
            medicine.Usage = medicineDto.Usage;

            return medicine;
        }

        public static DailyTask Update(this DailyTask dailytask, DailyTaskRequestDto taskDto)
        {
            dailytask.Name = taskDto.Name;
            dailytask.IsDone = taskDto.IsDone;

            return dailytask;
        }

        public static Species Update(this Species species, SpeciesRequestDto speciesDto)
        {

            species.Name = speciesDto.Name;
            species.ScientificName = speciesDto.ScientificName;

            return species;
        }

    }
}
