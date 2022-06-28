using IMS.Core.Entities;
using System;
using System.Collections.Generic;

namespace IMS.Core.Dtos
{
    /// <summary>
    /// Incident to display the user in a list.
    /// </summary>
    public class IncidentListItemDto
    {

    }

    /// <summary>
    /// Incident to display the user information in the details view.
    /// </summary>
    public class IncidentDetailsDto
    {
    }

    /// <summary>
    /// Incident to create or edit user.
    /// </summary>
    public class IncidentDto
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public bool read { get; set; }

    }

}