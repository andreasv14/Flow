using Flow.WebAPI.Application.Common.Interfaces;
using Flow.WebAPI.Domain.Entities;
using MediatR;

namespace Flow.WebAPI.Application.Items.Commands;

public class CreateItemCommand : IRequest<int>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int ItemType { get; set; }
}

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var newItem = new Item
        {
            Name = request.Name,
            Description = request.Description,
            Type = (Domain.Enums.ItemType)request.ItemType
        };

        await _context.Items.AddAsync(newItem);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}