using Flow.ResourceManager.Domain.Common;
using Flow.ResourceManager.Domain.Enums;

namespace Flow.ResourceManager.Domain.Entities;

public class Item : AuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ItemType Type { get; set; }
}