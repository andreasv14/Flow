using Flow.ResourceManager.Domain.Common;

namespace Flow.ResourceManager.Domain.Entities
{
    public class Trader : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }
    }
}
