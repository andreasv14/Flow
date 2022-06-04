namespace Flow.WebAPI.Domain.Entities;

public class Trader : BaseAuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsCustomer { get; set; }

    public bool IsSupplier { get; set; }
}
