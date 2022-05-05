using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Items.Commands;
using Flow.ResourceManager.Application.UnitTests.Fixtures;
using Flow.ResourceManager.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flow.ResourceManager.Application.UnitTests.Items.Commands
{
    public class RemoveItemCommandUnitTests :
        IClassFixture<DataSourceFixture>,
        IClassFixture<MappingProfilesFixture>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public RemoveItemCommandUnitTests(
            DataSourceFixture dataSourceFixture,
            MappingProfilesFixture mappingProfilesFixture)
        {
            _context = dataSourceFixture.Context;
            _mapper = mappingProfilesFixture.Mapper;
        }

        [Fact]
        public async Task Handle_RemoveCurrentItem()
        {
            // Arrange
            var item = new Item
            {
                Name = "Item asd",
                Description = "Item asd description",
                Type = Domain.Enums.ItemType.Product
            };

            await _context.Items.AddAsync(item);

            await _context.SaveChangesAsync(new System.Threading.CancellationToken());

            var removeItem = _context.Items.FirstOrDefault(i => i.Name == item.Name);

            var command = new RemoveItemCommandHandler(_context, _mapper);

            var request = new RemoveItemCommand
            {
                ItemId = removeItem.Id
            };

            // Act
            await command.Handle(request, new System.Threading.CancellationToken());

            // Assert
            var i = _context.Items.FirstOrDefault(i => i.Name == item.Name);
            Assert.Null(i);
        }
    }
}
