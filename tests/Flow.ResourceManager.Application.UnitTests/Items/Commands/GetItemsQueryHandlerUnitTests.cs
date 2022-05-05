using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Items.Queries;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Items.Commands
{
    public class GetItemsQueryHandlerUnitTests :
        IClassFixture<DataSourceFixture>, 
        IClassFixture<MappingProfilesFixture>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetItemsQueryHandlerUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task GetItemsQueryHandler_ReturnItemList()
        {
            // Arrange
            var request = new GetItemsQuery();

            var command = new GetItemsQueryHandler(_context, _mapper);

            // Act
            var results = await command.Handle(request, new System.Threading.CancellationToken());

            // Assert
            Assert.NotEmpty(results);
        }
    }
}
