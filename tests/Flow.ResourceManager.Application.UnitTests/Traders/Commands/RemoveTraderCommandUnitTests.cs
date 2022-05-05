using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Traders.Commands;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using Flow.ResourceManager.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Traders.Commands
{
    public class RemoveTraderCommandUnitTests : 
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RemoveTraderCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle_RemoveCurrent()
        {
            // Arrange
            var trader = new Trader
            {
                Name = "Item asd",
                Description = "Item asd description",
            };

            await _context.Traders.AddAsync(trader);

            await _context.SaveChangesAsync(new System.Threading.CancellationToken());

            var removeTrader = _context.Traders.FirstOrDefault(i => i.Name == trader.Name);

            var command = new RemoveTraderCommandHandler(_context, _mapper);

            var request = new RemoveTraderCommand
            {
                TraderId = removeTrader.Id
            };

            // Act
            await command.Handle(request, new System.Threading.CancellationToken());

            // Assert
            var i = _context.Traders.FirstOrDefault(i => i.Name == trader.Name);
            Assert.Null(i);
        }
    }
}