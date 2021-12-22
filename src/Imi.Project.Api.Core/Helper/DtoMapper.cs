using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

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
        public static DailyTaskResponseDto MapToDto(this DailyTask task)
        {
            return new DailyTaskResponseDto
            {
                Id = task.Id,
                Description = task.Description,
                IsDone = task.IsDone
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
                Gender = bird.Gender.ToString(),
                HatchDate = bird.HatchDate,
                Image = GetFullImageUrl(bird.Image),
                Cage = new CageResponseDto
                {
                    Id = bird.Cage.Id,
                    Name = bird.Cage.Name
                }
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
                Image = GetFullImageUrl(cage.Image),
                Location = cage.Location,
                Birds = cage.Birds?.Select(b => b.Id).ToList(),
                DailyTasks = cage.DailyTasks?.MapToDtoList()
            };
        }

        public static IEnumerable<CageResponseDto> MapToDtoList(this IEnumerable<Cage> cages)
        {
            return cages.Select(c => c.MapToDto()).ToList();
        }

        public static ApplicationUserResponseDto MapToDto(this ApplicationUser user)
        {
            return new ApplicationUserResponseDto
            {
                Id = user.Id,
                Name = user.UserName,
                Birds = user.Birds?.Select(b => b.Id),
                Cages = user.Cages?.Select(b => b.Id),
                Medicines = user.Medicines?.Select(b => b.Id)
            };
        }

        public static IEnumerable<ApplicationUserResponseDto> MapToDtoList(this IEnumerable<ApplicationUser> users)
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

        public static IEnumerable<MedicineResponseDto> MapToDtoList(this IEnumerable<Medicine> medicines)
        {
            return medicines.Select(u => u.MapToDto()).ToList();
        }

        public static PrescriptionResponseDto MapToDto(this Prescription prescription)
        {
            var prescriptionDto = new PrescriptionResponseDto
            {
                Id = prescription.Id,
                Medicine = prescription.Medicine.MapToDto(),
                StartDate = prescription.StartDate,
                EndDate = prescription.EndDate

            };
            var birds = prescription.BirdPrescriptions?.Select(b => b.Bird);
            List<BirdResponseDto> birdlist = new List<BirdResponseDto>();
            foreach (var bird in birds)
            {
                var newbirddto = new BirdResponseDto
                {
                    Name = bird.Name,
                    Cage = new CageResponseDto
                    {
                        Id = bird.Cage.Id,
                        Name = bird.Cage.Name
                    },
                    Image = GetFullImageUrl(bird.Image)
                };
                birdlist.Add(newbirddto);
            }
            prescriptionDto.Birds = birdlist;
            return prescriptionDto;
        }

        public static IEnumerable<PrescriptionResponseDto> MapToDtoList(this IEnumerable<Prescription> presciptions)
        {
            return presciptions.Select(u => u.MapToDto()).ToList();
        }

        private static string GetFullImageUrl(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                return null;
            }

            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var scheme = httpContextAccessor.HttpContext.Request.Scheme; // example: https or http
            var url = httpContextAccessor.HttpContext.Request.Host.Value; // example: localhost:5001, howest.be, steam.com, localhost:44785, ...

            var fullImageUrl = $"{scheme}://{url}/{image.Replace("\\", "/")}";

            return fullImageUrl;
        }

    }
}
