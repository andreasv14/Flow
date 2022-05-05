using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Traders.Queries
{
    public class UnitTestBase :
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        public UnitTestBase(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            Context = dataSourceFixture.Context;
            Mapper = mappingProfilesFixture.Mapper;
        }

        public IApplicationDbContext Context { get; }

        public IMapper Mapper { get; }
    }
}
