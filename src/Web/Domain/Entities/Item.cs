using Flow.WebAPI.Domain.Enums;

namespace Flow.WebAPI.Domain.Entities;

public class Item : BaseAuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ItemType Type { get; set; }
}