using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities.Pagination
{
    public class PaginationMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalOfItems { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public PaginationMetaData(int currentPage, int totalOfItems, int itemsPerPage)
        {
            CurrentPage = currentPage;
            TotalOfItems = totalOfItems;
            TotalPages = (int)Math.Ceiling(totalOfItems / (double)itemsPerPage);
        }
    }

}
