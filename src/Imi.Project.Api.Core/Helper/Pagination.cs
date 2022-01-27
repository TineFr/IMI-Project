using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Imi.Project.Api.Core.Helper
{
    public static class Pagination
    {

        public static IEnumerable<T> AddPagination<T>(IEnumerable<T> list, PaginationParameters parameters) where T : class
        {
            return list.Skip((parameters.Page - 1) * parameters.ItemsPerPage)
                                             .Take(parameters.ItemsPerPage)
                                             .ToList();
        }
    }
}
