using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Items.Commands;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Items.Commands
{
    public class CreateItemCommandUnitTests : IClassFixture<DataSourceFixture>
    {
        private IApplicationDbContext _context;

        public CreateItemCommandUnitTests(DataSourceFixture dataSourceFixture)
        {
            _context = dataSourceFixture.Context;
        }

        [Fact]
        public async Task CreateItemCommandHandler_CreateItemCommandIsValid_AddItemIntoDataSource()
        {
            // Arrange
            var request = new CreateItemCommand
            {
                Name = "Item A",
                Description = "Item A description",
                ItemType = 0
            };

            var command = new CreateItemCommandHandler(_context);

            // Act
            await command.Handle(request, new System.Threading.CancellationToken());

            // Assert
            var item = _context.Items.FirstOrDefault(i => i.Name == request.Name);
            Assert.NotNull(item);
        }
    }
}