
using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class Account
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        public string ProviderAccountId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Type { get; set; }

        public string? RefreshToken { get; set; }

        public string? AccessToken { get; set; }

        public int? ExpiresAt { get; set; }

        public string? TokenType { get; set; }

        public string? Scope { get; set; }

        public string? IdToken { get; set; }

        public string? SessionState { get; set; }

        public User User { get; set; }

    }
}
