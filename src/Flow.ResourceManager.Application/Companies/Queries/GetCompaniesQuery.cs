using Flow.ResourceManager.Application.Companies.Dtos;

namespace Flow.ResourceManager.Application.Companies.Queries
{
    public class GetCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {
    }

    public class GetCompaniesQueryHandler : CommandBase, IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        public GetCompaniesQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await Context.Companies.ToListAsync();

            return Mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
    }
}