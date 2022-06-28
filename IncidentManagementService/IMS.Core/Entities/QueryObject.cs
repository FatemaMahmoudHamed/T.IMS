using System;

namespace IMS.Infrastructure.Entities
{
    public class QueryObject
    {
        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }

    public class IncidentQueryObject : QueryObject
    {
        //public int Id { get; set; }
        //public int CustomerId { get; set; }
        //public string Details { get; set; }
        //public bool read { get; set; }
    }



}