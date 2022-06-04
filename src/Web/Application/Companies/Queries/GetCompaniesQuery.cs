using Flow.WebAPI.Application.Companies.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Companies.Queries
{
    public class GetCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {
    }

    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetCompaniesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await context.Companies.ToListAsync();

            return mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
    }
}