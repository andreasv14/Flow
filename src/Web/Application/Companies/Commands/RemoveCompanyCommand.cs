using AutoMapper;
using Flow.WebAPI.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Companies.Commands
{
    public class RemoveCompanyCommand : IRequest<int>
    {
        public Guid CompanyId { get; set; }
    }

    public class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommand, int>
    {
        private readonly IApplicationDbContext context;

        public RemoveCompanyCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
        }

        public async Task<int> Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
        {
            var currentCompany = await context.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId);
            if (currentCompany == null)
            {
                throw new NullReferenceException($"Cannot find company with id {request.CompanyId}");
            }

            context.Companies.Remove(currentCompany);

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
