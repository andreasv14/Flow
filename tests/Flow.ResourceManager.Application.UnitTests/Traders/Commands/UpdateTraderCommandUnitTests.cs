using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Traders.Commands;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Traders.Commands
{
    public class UpdateTraderCommandUnitTests : 
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTraderCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle_UpdateCurrentTrader()
        {
            var currentTrader = _context.Traders.FirstOrDefault();

            var request = new UpdateTraderCommand
            {
                TraderId = currentTrader.Id,
                Description = "Update description",
                Name = "Update name",
                IsCustomer = true,
                IsSupplier = true
            };

            var handler = new UpdateTraderCommandHandler(_context, _mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            var updatedTrader = _context.Traders.FirstOrDefault(x => x.Id == currentTrader.Id);

            Assert.True(result == 1);
            Assert.True(updatedTrader.Name == request.Name);
        }
    }
}
