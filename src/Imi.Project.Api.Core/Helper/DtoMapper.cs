﻿using Imi.Project.Api.Core.Dtos.Responses;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Helper
{
    public static class DtoMapper
    {


        public static SpeciesResponseDto MapToDto(this Species species)
        {
            return new SpeciesResponseDto
            {
                Id = species.Id,
                Name = species.Name,
                ScientificName = species.ScientificName
            };
        }
        public static IEnumerable<SpeciesResponseDto> MapToDtoList(this IEnumerable<Species> species)
        {
            return species.Select(s => s.MapToDto()).ToList();
        }
        public static DailyTaskResponseDto MapToDto(this DailyTask tasks)
        {
            return new DailyTaskResponseDto
            {
                Id = tasks.Id,
                Name = tasks.Name,
            };
        }

        public static IEnumerable<DailyTaskResponseDto> MapToDtoList(this IEnumerable<DailyTask> tasks)
        {
            return tasks.Select(t => t.MapToDto()).ToList();
        }


        public static BirdResponseDto MapToDto(this Bird bird)
        {
            return new BirdResponseDto
            {
                Id = bird.Id,
                Name = bird.Name,
                Species = bird.Species?.MapToDto(),
                Food = bird.Food,
                Gender = bird.Gender,
                HatchDate = bird.HatchDate,
                Image = bird.Image,
                Cage = bird.Cage.Name,        
            };
        }

        public static IEnumerable<BirdResponseDto> MapToDtoList(this IEnumerable<Bird> birds)
        {
            return birds.Select(b => b.MapToDto()).ToList();
        }

        public static CageResponseDto MapToDto(this Cage cage)
        {
            return new CageResponseDto
            {
                Id = cage.Id,
                Name = cage.Name,
                Image = cage.Image,
                Location = cage.Location,
                Birds = cage.Birds?.MapToDtoList(),
                DailyTasks = cage.DailyTasks?.MapToDtoList()
            };
        }

        public static IEnumerable<CageResponseDto> MapToDtoList(this IEnumerable<Cage> cages)
        {
            return cages.Select(c => c.MapToDto()).ToList();
        }

        public static UserResponseDto MapToDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Birds = user.Birds?.Select(b => b.Id),
                Cages = user.Cages?.Select(b => b.Id),
                Medicines = user.Medicines?.Select(b => b.Id)
            };
        }

        public static IEnumerable<UserResponseDto> MapToDtoList(this IEnumerable<User> users)
        {
            return users.Select(u => u.MapToDto()).ToList();
        }

        public static MedicineResponseDto MapToDto(this Medicine medicine)
        {
            return new MedicineResponseDto
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Usage = medicine.Usage,          
            };
        }

        public static IEnumerable<MedicineResponseDto> MaptoDToList(this IEnumerable<Medicine> medicines)
        {
            return medicines.Select(u => u.MapToDto()).ToList();
        }

    }
}
