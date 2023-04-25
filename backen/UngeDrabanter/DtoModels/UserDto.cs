using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UngeDrabanter.DtoModels
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        public Guid? UserId { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
