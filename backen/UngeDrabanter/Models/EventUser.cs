using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class EventUser
    {
        [Key]
        [Required]
        public Guid EventId { get; set; }

        [Key]
        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Event Event { get; set; }
    }
}
