using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Companies.Commands;
using Flow.ResourceManager.Application.UnitTests.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Flow.ResourceManager.Application.UnitTests.Companies
{
    public class UpdateCompanyCommandUnitTests : 
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle_UpdateCurrentItem()
        {
            var currentCompany = _context.Companies.FirstOrDefault();

            var request = new UpdateCompanyCommand
            {
                Company = new Application.Companies.Dtos.CompanyDto
                {
                    CompanyId = currentCompany.Id,
                    Description = "Update description",
                    Name = "Update name",
                }
            };

            var handler = new UpdateCompanyCommandHandler(_context, _mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            var updatedCompany = _context.Companies.FirstOrDefault(x => x.Id == currentCompany.Id);

            Assert.True(result == 1);
            Assert.True(updatedCompany.Name == request.Company.Name);
        }
    }
}
