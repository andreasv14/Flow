using AutoMapper;
using Flow.ResourceManager.Application.Common.Commands;
using Flow.ResourceManager.Application.Common.Interfaces;
using MediatR;

namespace Flow.ResourceManager.Application.Traders.Commands
{
    public class RemoveTraderCommand : IRequest<int>
    {
        public Guid TraderId { get; set; }
    }

    public class RemoveTraderCommandHandler : CommandBase, IRequestHandler<RemoveTraderCommand, int>
    {
        public RemoveTraderCommandHandler(
            IApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(RemoveTraderCommand request, CancellationToken cancellationToken)
        {
            var currentTrader = Context.Traders.FirstOrDefault(t => t.Id == request.TraderId);
            if (currentTrader == null)
            {
                throw new NullReferenceException($"Cannot find trader with id {request.TraderId}");
            }

            Context.Traders.Remove(currentTrader);

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}