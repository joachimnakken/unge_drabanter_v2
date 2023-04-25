using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UngeDrabanter.DtoModels
{
    public class EventDto
    {
        [JsonPropertyName("eventHostId")]
        public Guid? EventHostId { get; set; }

        [JsonPropertyName("eventId")]
        public Guid? EventId { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("eventUri")]
        public string? EventUri { get; set; }

        [JsonPropertyName("imageUri")]
        public string? ImageUri { get; set; }

        [JsonPropertyName("eventCode")]
        public string EventCode { get; set; }

        [JsonPropertyName("eventDateTime")]
        public DateTime? EventDateTime { get; set; }

    }
}