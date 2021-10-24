
using Imi.Project.Api.Core.Dtos.Birds;
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



    }
}
