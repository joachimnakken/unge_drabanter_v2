using Newtonsoft.Json;

namespace UngeDrabanter.DtoModels
{
    public class UserDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("emailVerified")]
        public int? EmailVerified { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; } = string.Empty;

    }
}