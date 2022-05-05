using AutoMapper;
using Flow.ResourceManager.Application.Common.Commands;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Traders.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Traders.Commands
{
    public class UpdateTraderCommand : IRequest<int>
    {
        public Guid TraderId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }
    }

    public class UpdateTraderCommandHandler : CommandBase, IRequestHandler<UpdateTraderCommand, int>
    {
        public UpdateTraderCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(UpdateTraderCommand request, CancellationToken cancellationToken)
        {
            var currentTrader = await Context.Traders.FirstOrDefaultAsync(t => t.Id == request.TraderId);
            if (currentTrader == null)
            {
                throw new NullReferenceException($"Cannot find trader with traderId {request.TraderId}");
            }

            currentTrader.Name = request.Name;
            currentTrader.Description = request.Description;
            currentTrader.IsCustomer = request.IsCustomer;
            currentTrader.IsSupplier = request.IsSupplier;

            Context.Traders.Update(currentTrader);

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }


}
