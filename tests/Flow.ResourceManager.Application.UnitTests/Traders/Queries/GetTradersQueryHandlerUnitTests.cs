using Flow.ResourceManager.Application.Traders.Queries;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Traders.Queries
{

    public class GetTradersQueryHandlerUnitTests : UnitTestBase
    {
        public GetTradersQueryHandlerUnitTests(DataSourceFixture dataSourceFixture, MappingProfilesFixture mappingProfilesFixture) : base(dataSourceFixture, mappingProfilesFixture)
        {
        }

        [Fact]
        public async Task Handle_ReturnTraderList()
        {
            var request = new GetTradersQuery();

            var handler = new GetTradersQueryHandler(Context, Mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotEmpty(result);
        }
    }
}
