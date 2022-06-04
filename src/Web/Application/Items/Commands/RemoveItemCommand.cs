using AutoMapper;
using Flow.WebAPI.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Items.Commands
{
    public class RemoveItemCommand : IRequest<int>
    {
        public Guid ItemId { get; set; }
    }

    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, int>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public RemoveItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var currentItem = await context.Items.FirstOrDefaultAsync(x => x.Id == request.ItemId);
            if (currentItem == null)
            {
                throw new NullReferenceException($"Cannot find item with {request.ItemId}");
            }

            context.Items.Remove(currentItem);

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}