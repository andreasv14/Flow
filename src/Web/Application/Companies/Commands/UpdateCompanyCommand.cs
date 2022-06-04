using Flow.WebAPI.Application.Companies.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Companies.Commands
{
    public class UpdateCompanyCommand : IRequest<int>
    {
        public CompanyDto Company { get; set; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, int>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public UpdateCompanyCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var currentCompany = await context.Companies.FirstOrDefaultAsync(c => c.Id == request.Company.Id);
            if (currentCompany == null)
            {
                throw new NullReferenceException($"Cannot find company with id {request.Company.Id}");
            }

            currentCompany.Name = request.Company.Name;
            currentCompany.Description = request.Company.Description;

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}