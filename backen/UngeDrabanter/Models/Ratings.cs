using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace UngeDrabanter.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Key]
        [Required]
        public Guid EventId { get; set; }

        [Required]
        public decimal Value { get; set; }

        public Item Item { get; set; }

        public Event Event{ get; set; }

        public User User { get; set; }

    }
}
