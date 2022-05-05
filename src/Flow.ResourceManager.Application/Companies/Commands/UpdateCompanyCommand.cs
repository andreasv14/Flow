using Flow.ResourceManager.Application.Companies.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Companies.Commands
{
    public class UpdateCompanyCommand : IRequest<int>
    {
        public CompanyDto Company { get; set; }
    }

    public class UpdateCompanyCommandHandler : CommandBase, IRequestHandler<UpdateCompanyCommand, int>
    {
        public UpdateCompanyCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var currentCompany = await Context.Companies.FirstOrDefaultAsync(c => c.Id == request.Company.CompanyId);
            if (currentCompany == null)
            {
                throw new NullReferenceException($"Cannot find company with id {request.Company.CompanyId}");
            }

            currentCompany.Name = request.Company.Name;
            currentCompany.Description = request.Company.Description;

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}