using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class PagedModelResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public bool isFirstpage { get; set; } = false;
        public bool isLastpage { get; set; } = false;
        public PagedModelResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
        }
    }
}
