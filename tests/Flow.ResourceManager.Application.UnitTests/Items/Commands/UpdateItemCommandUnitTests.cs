using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Items.Commands;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Items.Commands
{
    public class UpdateItemCommandUnitTests :
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public UpdateItemCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle__UpdateCurrentItem()
        {
            var currentItem = _context.Items.FirstOrDefault();

            var request = new UpdateItemCommand
            {
                ItemId = currentItem.Id,
                Description = "Update description",
                Name = "Update name",
                Type = 1
            };

            var handler = new UpdateItemCommandHandler(_context, _mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            var updatedItem = _context.Items.FirstOrDefault(x => x.Id == currentItem.Id);

            Assert.True(result == 1);
            Assert.True(updatedItem.Name == request.Name);
        }
    }
}