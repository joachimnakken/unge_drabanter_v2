using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.DtoModels
{
    public class SessionDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty("sessionToken")]
        public string SessionToken { get; set; } = string.Empty;

        [Required]
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

    }
}