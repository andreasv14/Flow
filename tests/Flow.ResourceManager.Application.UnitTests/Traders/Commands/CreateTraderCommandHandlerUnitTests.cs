using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Traders.Commands;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Traders.Commands
{
    public class CreateTraderCommandHandlerUnitTests : IClassFixture<DataSourceFixture>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateTraderCommandHandlerUnitTests(DataSourceFixture dataSourceFixture)
        {
            _context = dataSourceFixture.Context;
        }

        [Fact]
        public async Task Handle_CreateTraderCommandIsValid_AddTraderIntoDataSource()
        {
            // Arrange 
            var request = new CreateTraderCommand()
            {
                Name = "Trader unit test",
                Description = "Trader description unit test",
                IsCustomer = true,
                IsSupplier = false
            };

            var commandHandler = new CreateTraderCommandHandler(_context);

            // Act
            var result = await commandHandler.Handle(request, new System.Threading.CancellationToken());

            // Assert
            var trader = _context.Traders.FirstOrDefault(i => i.Name == request.Name);
            Assert.NotNull(trader);
            Assert.Equal(1, result);
        }
    }
}