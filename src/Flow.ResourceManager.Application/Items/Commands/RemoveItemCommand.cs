using AutoMapper;
using Flow.ResourceManager.Application.Common.Commands;
using Flow.ResourceManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Items.Commands
{
    public class RemoveItemCommand : IRequest<int>
    {
        public Guid ItemId { get; set; }
    }

    public class RemoveItemCommandHandler : CommandBase, IRequestHandler<RemoveItemCommand, int>
    {
        public RemoveItemCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var currentItem = await Context.Items.FirstOrDefaultAsync(x => x.Id == request.ItemId);
            if (currentItem == null)
            {
                throw new NullReferenceException($"Cannot find item with {request.ItemId}");
            }

            Context.Items.Remove(currentItem);

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}