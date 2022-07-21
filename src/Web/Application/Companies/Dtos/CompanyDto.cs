using Flow.WebAPI.Application.Common.Mappings;

namespace Flow.WebAPI.Application.Companies.Dtos
{
    public class CompanyDto : IMapFrom<Company>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}