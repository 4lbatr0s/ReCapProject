using System;

namespace Core.Entities.Concrete.Dto
{
    public class UserOperationClaimForCreationDto:IDto
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
