using AutoMapper;
using Flow.ResourceManager.Application.Common.Commands;
using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Domain.Entities;
using MediatR;

namespace Flow.ResourceManager.Application.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class CreateCompanyCommandHandler : CommandBase, IRequestHandler<CreateCompanyCommand, int>
    {
        public CreateCompanyCommandHandler(
            IApplicationDbContext context,
            IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var newCompany = Mapper.Map<Company>(request);

            await Context.Companies.AddAsync(newCompany);

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}