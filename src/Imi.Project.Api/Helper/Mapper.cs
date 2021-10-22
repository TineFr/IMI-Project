using Imi.Project.Api.Core.Entities;
using Imi.Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Helper
{
    public static class Mapper
    {

        public static SpeciesResponseDto MaptoDto(this Species species)
        {
            return new SpeciesResponseDto
            {
                Id = species.Id,
                Name = species.Name,
                ScientificName = species.ScientificName
            };
        }
        public static IEnumerable<SpeciesResponseDto> MaptoDtoList(this IEnumerable<Species> species)
        {
            return species.Select(s => s.MaptoDto()).ToList();
        }
        public static DailyTaskResponseDto MaptoDto(this DailyTask tasks)
        {
            return new DailyTaskResponseDto
            {
                Id = tasks.Id,
                Name = tasks.Name,
            };
        }

        public static IEnumerable<DailyTaskResponseDto> MaptoDtoList(this IEnumerable<DailyTask> tasks)
        {
            return tasks.Select(t => t.MaptoDto()).ToList();
        }


        public static BirdResponseDto MaptoDto(this Bird bird)
        {
            return new BirdResponseDto
            {
                Id = bird.Id,
                Name = bird.Name,
                Species = bird.Species.MaptoDto(),
                Food = bird.Food,
                Gender = bird.Gender,
                HatchDate = bird.HatchDate,
                Image = bird.Image,
                User = bird.User.MaptoDto(),
                Medicines = bird.BirdMedicines.Select(m => m.Medicine.MaptoDto()).ToList()
            };
        }

        public static IEnumerable<BirdResponseDto> MaptoDtoList(this IEnumerable<Bird> birds)
        {
            return birds.Select(b => b.MaptoDto()).ToList();
        }

        public static CageResponseDto MaptoDto(this Cage cage)
        {
            return new CageResponseDto
            {
                Id = cage.Id,
                Name = cage.Name,
                Image = cage.Image,
                User = cage.User.MaptoDto(),
                Birds = cage.Birds.MaptoDtoList()

            };
        }

        public static IEnumerable<CageResponseDto> MaptoDtoList(this IEnumerable<Cage> cages)
        {
            return cages.Select(c => c.MaptoDto()).ToList();
        }

        public static UserResponseDto MaptoDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Birds = user.Birds.MaptoDtoList(),
                Cages = user.Cages.MaptoDtoList(),
                Medicines = user.Medicines.MaptoDtoList()

            };
        }

        public static IEnumerable<UserResponseDto> MaptoDtoList(this IEnumerable<User> users)
        {
            return users.Select(u => u.MaptoDto()).ToList();
        }

        public static MedicineResponseDto MaptoDto(this Medicine medicine)
        {
            return new MedicineResponseDto
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Usage = medicine.Usage,
                User = medicine.User.MaptoDto()
            };
        }

        public static IEnumerable<MedicineResponseDto> MaptoDtoList(this IEnumerable<Medicine> medicines)
        {
            return medicines.Select(u => u.MaptoDto()).ToList();
        }

    }
}
