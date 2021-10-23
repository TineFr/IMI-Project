using Imi.Project.Api.Core.Dtos.Requests;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Helper
{
    public static class EntityMapper
    {


        public static User MapToEntity(this UserRequestDto user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name

            };
        }

    }
}
