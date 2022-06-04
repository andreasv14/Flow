using AutoMapper;
using Flow.WebAPI.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Items.Commands
{
    public class UpdateItemCommand : IRequest<int>
    {
        public Guid ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }
    }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, int>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public UpdateItemCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var currentItem = await context.Items.FirstOrDefaultAsync(x => x.Id == request.ItemId);
            if (currentItem == null)
            {
                throw new NullReferenceException($"Item with {request.ItemId} cannot be found");
            }

            currentItem.Description = request.Description;
            currentItem.Name = request.Name;
            currentItem.Type = (Domain.Enums.ItemType)request.Type;

            context.Items.Update(currentItem);

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
