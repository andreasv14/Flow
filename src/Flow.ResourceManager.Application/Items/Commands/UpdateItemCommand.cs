using AutoMapper;
using Flow.ResourceManager.Application.Common.Commands;
using Flow.ResourceManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Items.Commands
{
    public class UpdateItemCommand : IRequest<int>
    {
        public Guid ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }
    }

    public class UpdateItemCommandHandler : CommandBase, IRequestHandler<UpdateItemCommand, int>
    {
        public UpdateItemCommandHandler(
            IApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var currentItem = await Context.Items.FirstOrDefaultAsync(x => x.Id == request.ItemId);
            if (currentItem == null)
            {
                throw new NullReferenceException($"Item with {request.ItemId} cannot be found");
            }

            currentItem.Description = request.Description;
            currentItem.Name = request.Name;
            currentItem.Type = (Domain.Enums.ItemType)request.Type;

            Context.Items.Update(currentItem);

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
