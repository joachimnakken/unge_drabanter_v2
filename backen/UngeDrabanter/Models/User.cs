using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class User
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime? EmailVerified { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public ICollection<Account> Accounts { get; set; }

        //public IEnumerable<Event> ParticipatingEvents { get; set; }

        //public IEnumerable<Rating> Ratings { get; set; }

        public IEnumerable<Event> CreatedEvents { get; set; }

    }
}
