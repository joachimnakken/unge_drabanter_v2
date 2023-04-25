using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class User
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        //public IEnumerable<Event> ParticipatingEvents { get; set; }

        //public IEnumerable<Rating> Ratings { get; set; }

        public IEnumerable<Event> CreatedEvents { get; set; }

    }
}
