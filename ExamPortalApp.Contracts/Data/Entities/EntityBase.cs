using System.ComponentModel.DataAnnotations;

namespace ExamPortalApp.Contracts.Data.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
