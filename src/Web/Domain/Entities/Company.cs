namespace Flow.WebAPI.Domain.Entities;

public class Company : BaseAuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
