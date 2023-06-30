using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.DtoModels
{
    public class AccountDto
    {
        [Required]
        [JsonProperty("provider")]
        public string Provider { get; set; } = string.Empty;

        [Required]
        [JsonProperty("providerAccountId")]
        public string ProviderAccountId { get; set; } = string.Empty;

        [Required]
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [Required]
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("refresh_token")]
        public string? RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty("expires_at")]
        public int? ExpiresAt { get; set; }

        [JsonProperty("token_type")]
        public string? TokenType { get; set; }

        [JsonProperty("scope")]
        public string? Scope { get; set; }

        [JsonProperty("id_token")]
        public string? IdToken { get; set; }

        [JsonProperty("session_state")]
        public string? SessionState { get; set; }

    }
}