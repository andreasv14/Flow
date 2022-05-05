using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Companies.Commands;
using System.Threading.Tasks;

namespace Flow.ResourceManager.Application.UnitTests.Companies
{
    public class CreateCompanyCommandUnitTests : 
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCompanyCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle_CreateCompany()
        {
            var request = new CreateCompanyCommand
            {
                Name = "Unit test new company",
                Description = "Unit test new company desc"
            };

            var command = new CreateCompanyCommandHandler(_context, _mapper);

            var result = await command.Handle(request, new System.Threading.CancellationToken());
            

        }
    }
}
