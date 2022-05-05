namespace Flow.ResourceManager.Application.Companies.Commands
{
    public class RemoveCompanyCommand : IRequest<int>
    {
        public Guid CompanyId { get; set; }
    }

    public class RemoveCompanyCommandHandler : CommandBase, IRequestHandler<RemoveCompanyCommand, int>
    {
        public RemoveCompanyCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
        {
            var currentCompany = await Context.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId);
            if (currentCompany == null)
            {
                throw new NullReferenceException($"Cannot find company with id {request.CompanyId}");
            }

            Context.Companies.Remove(currentCompany);

            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
