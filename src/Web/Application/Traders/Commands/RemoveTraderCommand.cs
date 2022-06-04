using AutoMapper;
using Flow.WebAPI.Application.Common.Interfaces;
using MediatR;

namespace Flow.WebAPI.Application.Traders.Commands
{
    public class RemoveTraderCommand : IRequest<int>
    {
        public Guid TraderId { get; set; }
    }

    public class RemoveTraderCommandHandler : IRequestHandler<RemoveTraderCommand, int>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public RemoveTraderCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveTraderCommand request, CancellationToken cancellationToken)
        {
            var currentTrader = context.Traders.FirstOrDefault(t => t.Id == request.TraderId);
            if (currentTrader == null)
            {
                throw new NullReferenceException($"Cannot find trader with id {request.TraderId}");
            }

            context.Traders.Remove(currentTrader);

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}