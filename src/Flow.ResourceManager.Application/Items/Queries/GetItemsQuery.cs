using AutoMapper;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Application.Items.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Items.Queries;

public class GetItemsQuery : IRequest<IEnumerable<ItemDto>>
{
}

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDto>>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetItemsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await context.Items.ToListAsync();

        return mapper.Map<IEnumerable<ItemDto>>(items);
    }
}
