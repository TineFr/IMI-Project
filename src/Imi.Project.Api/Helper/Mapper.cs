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



    }
}
