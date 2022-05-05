﻿
namespace Flow.ResourceManager.Domain.Common
{
    public interface IAuditableEntity
    {
        DateTime Created { get; set; }
        
        DateTime? LastModified { get; set; }
    }
}