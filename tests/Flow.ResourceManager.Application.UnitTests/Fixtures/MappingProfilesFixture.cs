using AutoMapper;
using System;

namespace Flow.ResourceManager.Application.UnitTests.Fixtures
{
    public class MappingProfilesFixture : IDisposable
    {
        public MappingProfilesFixture()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Common.Mapping.MappingProfiles());
            });

            Mapper = mapper.CreateMapper();
        }

        public IMapper Mapper { get; set; }

        public void Dispose()
        {
            Mapper = null;
        }
    }
}