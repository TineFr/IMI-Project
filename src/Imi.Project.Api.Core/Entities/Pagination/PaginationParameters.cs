using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities.Pagination
{
    public class PaginationParameters
    {
        public int MaxItemsPerPage { get; set; } = 20;

        private int itemsPerPage;

        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = itemsPerPage > MaxItemsPerPage ? MaxItemsPerPage : value;}
        }
        public int CurrentPage { get; set; } = 1;


    }
}
