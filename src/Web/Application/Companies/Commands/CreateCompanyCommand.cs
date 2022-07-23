using FluentValidation;

namespace Flow.WebAPI.Application.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name cannot be null or empty");
        }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public CreateCompanyCommandHandler(
            IApplicationDbContext context,
            IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var newCompany = mapper.Map<Company>(request);

            await context.Companies.AddAsync(newCompany);

            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}