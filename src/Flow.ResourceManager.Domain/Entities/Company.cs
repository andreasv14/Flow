using Flow.ResourceManager.Domain.Common;

namespace Flow.ResourceManager.Domain.Entities
{
    public class Company : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}