using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;

namespace Flow.ResourceManager.Application.Common.Commands
{
    public abstract class CommandBase
    {
        protected CommandBase(
            IApplicationDbContext context,
            IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IApplicationDbContext Context { get; }

        public IMapper Mapper { get; }
    }
}
