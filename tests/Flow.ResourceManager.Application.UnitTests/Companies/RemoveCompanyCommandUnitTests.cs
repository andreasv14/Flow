using AutoMapper;
using Flow.ResourceManager.Application.Companies.Commands;
using Flow.ResourceManager.Application.UnitTests.Persistence;
using Flow.ResourceManager.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Flow.ResourceManager.Application.UnitTests.Companies
{
    public class RemoveCompanyCommandUnitTests :
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private FakeApplicationDbContext _context;
        private IMapper _mapper;

        public RemoveCompanyCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle_RemoveCurrentCompany()
        {
            // Arrange
            var company = new Company
            {
                Name = "Item asd",
                Description = "Item asd description",
            };

            await _context.Companies.AddAsync(company);

            await _context.SaveChangesAsync(new System.Threading.CancellationToken());

            var removeCompany = _context.Companies.FirstOrDefault(i => i.Name == company.Name);

            var command = new RemoveCompanyCommandHandler(_context, _mapper);

            var request = new RemoveCompanyCommand
            {
                CompanyId = removeCompany.Id
            };

            // Act
            await command.Handle(request, new System.Threading.CancellationToken());

            // Assert
            var i = _context.Companies.FirstOrDefault(i => i.Name == company.Name);
            Assert.Null(i);
        }
    }
}
