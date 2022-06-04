using Flow.WebAPI.Application.Traders.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Traders.Queries
{
    public class GetTradersQuery : IRequest<IEnumerable<TraderDto>>
    {
    }

    public class GetTradersQueryHandler : IRequestHandler<GetTradersQuery, IEnumerable<TraderDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetTradersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TraderDto>> Handle(GetTradersQuery request, CancellationToken cancellationToken)
        {
            var traders = await context.Traders.ToListAsync();

            return mapper.Map<IEnumerable<TraderDto>>(traders);
        }
    }
}