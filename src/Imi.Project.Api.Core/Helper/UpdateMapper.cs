using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Linq;

namespace Imi.Project.Api.Core.Helper
{
    public static class UpdateMapper
    {
        public static ApplicationUser Update(this ApplicationUser user, ApplicationUserRequestDto dto)
        {
            user.UserName = dto.Name;
            return user;
        }
        public static Bird Update(this Bird bird, BirdRequestDto birdDto)
        {
            bird.Name = birdDto.Name;
            bird.CageId = birdDto.CageId;
            bird.Gender = birdDto.Gender;
            bird.Food = birdDto.Food;
            bird.HatchDate = birdDto.HatchDate;
            bird.SpeciesId = birdDto.SpeciesId;
            return bird;
        }

        public static Cage Update(this Cage cage, CageRequestDto cageDto)
        {

            cage.Name = cageDto.Name;
            cage.Location = cageDto.Location;

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
            dailytask.Description = taskDto.Description;
            dailytask.IsDone = taskDto.IsDone;

            return dailytask;
        }

        public static Species Update(this Species species, SpeciesRequestDto speciesDto)
        {

            species.Name = speciesDto.Name;
            species.ScientificName = speciesDto.ScientificName;
            species.Description = speciesDto.Description;
            return species;
        }




        public static Prescription Update(this Prescription prescription, PrescriptionRequestDto prescriptionDto)
        {
            prescription.EndDate = prescriptionDto.EndDate;
            prescription.StartDate = prescriptionDto.StartDate;
            prescription.MedicineId = prescriptionDto.Medicine;
            prescription.UserId = prescriptionDto.UserId;

            foreach (var bird in prescriptionDto.Birds)
            {
                if (!prescription.BirdPrescriptions.Select(bp => bp.BirdId).ToList().Contains(bird))
                {
                    var birdprescription = new BirdPrescription
                    {
                        BirdId = bird,
                    };
                    prescription.BirdPrescriptions.Add(birdprescription);
                }
            }
            var toDelete = prescription.BirdPrescriptions.Select(s => s.BirdId).ToList().Except(prescriptionDto.Birds).ToList();
            toDelete.ForEach(b => prescription.BirdPrescriptions.Remove(prescription.BirdPrescriptions.FirstOrDefault(c => c.BirdId.Equals(b))));
            return prescription;


        }

    }
}
