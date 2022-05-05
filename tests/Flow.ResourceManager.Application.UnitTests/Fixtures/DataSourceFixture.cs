using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.UnitTests.Persistence;
using Flow.ResourceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Flow.ResourceManager.Application.UnitTests.Fixtures
{
    public class DataSourceFixture : IDisposable
    {
        public DataSourceFixture()
        {
            var options = new DbContextOptionsBuilder<FakeApplicationDbContext>();
            Context = new FakeApplicationDbContext(options
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options);

            SeedData();
        }

        public FakeApplicationDbContext Context { get; private set; }

        private void SeedData()
        {
            // Items
            Context.Items.Add
            (
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Description = "Item A description",
                    Name = "Item A",
                    Type = Domain.Enums.ItemType.Utility
                });

            Context.Traders.Add
            (
                new Trader()
                {
                    Id = Guid.NewGuid(),
                    Description = "Trader A",
                    Name = "Trader A",
                });


            Context.Companies.Add
            (
                new Company()
                {
                    Id = Guid.NewGuid(),
                    Description = "Company A",
                    Name = "Company A description",
                });

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}