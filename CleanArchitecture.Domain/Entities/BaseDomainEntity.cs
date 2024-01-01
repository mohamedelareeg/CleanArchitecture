using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Cancelled { get; set; }

    }
}
