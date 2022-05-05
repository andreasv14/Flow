using AutoMapper;
using Flow.ResourceManager.Application.Common.Commands;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Traders.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Traders.Queries
{
    public class GetTradersQuery : IRequest<IEnumerable<TraderDto>>
    {
    }

    public class GetTradersQueryHandler : CommandBase, IRequestHandler<GetTradersQuery, IEnumerable<TraderDto>>
    {
        public GetTradersQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<TraderDto>> Handle(GetTradersQuery request, CancellationToken cancellationToken)
        {
            var traders = await Context.Traders.ToListAsync();

            return Mapper.Map<IEnumerable<TraderDto>>(traders);
        }
    }
}