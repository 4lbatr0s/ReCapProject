using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("Id")]
        public User User { get; set; }
        public int UserId { get; set; }


        [ForeignKey("Id")]
        public OperationClaim OperationClaim { get; set; }
        public int OperationClaimId { get; set; }
    }
}
