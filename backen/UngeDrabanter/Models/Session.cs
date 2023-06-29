using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class Session
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Expires { get; set; }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [StringLength(256)]
        public string SessionToken { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
