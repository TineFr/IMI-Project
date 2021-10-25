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
    }
}
