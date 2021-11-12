using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imi.Project.Api.Core.Helper
{
    public static class Pagination
    {

        public static IEnumerable<T> AddPagination<T>(IEnumerable<T> list, PaginationParameters parameters) /*where T : BaseEntity*/
        {
            return  list.Skip((parameters.Page - 1) * parameters.ItemsPerPage)
                                             .Take(parameters.ItemsPerPage)
                                             .ToList();
        }
    }
}
