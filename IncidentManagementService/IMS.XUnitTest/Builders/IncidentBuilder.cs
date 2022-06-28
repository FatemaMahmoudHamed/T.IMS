
using IMS.Core.Dtos;

namespace IMS.UnitTests.Builders
{
    public class IncidentBuilder
    {
        private IncidentDto _Incident = new IncidentDto();
        public IncidentBuilder CustomerId(int custId)
        {
            _Incident.CustomerId = custId;
            return this;
        }
        public IncidentBuilder Details(string Details)
        {
            _Incident.Details = Details;
            return this;
        }
        public IncidentBuilder read(bool read)
        {
            _Incident.read = read;
            return this;
        }

        public IncidentBuilder WithDefaultValues()
        {
            _Incident = new IncidentDto
            {
                CustomerId = (new CustomerBuilder().WithDefaultValues().Build()).Id.Value,
                Details="Deatils",
                read=false,
            };

            return this;
        }

        public IncidentDto Build() => _Incident;
    }
}
