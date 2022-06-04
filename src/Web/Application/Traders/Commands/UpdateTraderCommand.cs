using AutoMapper;
using Flow.WebAPI.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Traders.Commands
{
    public class UpdateTraderCommand : IRequest<int>
    {
        public Guid TraderId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }
    }

    public class UpdateTraderCommandHandler : IRequestHandler<UpdateTraderCommand, int>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public UpdateTraderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateTraderCommand request, CancellationToken cancellationToken)
        {
            var currentTrader = await context.Traders.FirstOrDefaultAsync(t => t.Id == request.TraderId);
            if (currentTrader == null)
            {
                throw new NullReferenceException($"Cannot find trader with traderId {request.TraderId}");
            }

            currentTrader.Name = request.Name;
            currentTrader.Description = request.Description;
            currentTrader.IsCustomer = request.IsCustomer;
            currentTrader.IsSupplier = request.IsSupplier;

            context.Traders.Update(currentTrader);

            return await context.SaveChangesAsync(cancellationToken);
        }
    }


}
