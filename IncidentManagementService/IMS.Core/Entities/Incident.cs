using System;
using System.Collections.Generic;

namespace IMS.Core.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public bool read { get; set; }
        public Customer Customer { get; set; }

    }
}
