using Flow.WebAPI.Application.Common.Interfaces;
using Flow.WebAPI.Domain.Entities;
using MediatR;

namespace Flow.WebAPI.Application.Traders.Commands
{
    public class CreateTraderCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }
    }

    public class CreateTraderCommandHandler : IRequestHandler<CreateTraderCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTraderCommandHandler(
            IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTraderCommand request, CancellationToken cancellationToken)
        {
            var newTrader = new Trader
            {
                Name = request.Name,
                Description = request.Description,
                IsCustomer = request.IsCustomer,
                IsSupplier = request.IsSupplier,
            };

            await _context.Traders.AddAsync(newTrader, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
