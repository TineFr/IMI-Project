﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities.Pagination
{
    public class PaginationParameters
    {
        const int MaxItemsPerPage  = 20;

        private int itemsPerPage;

        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = itemsPerPage > MaxItemsPerPage ? MaxItemsPerPage : value;}
        }
        public int Page { get; set; } = 1;


    }
}