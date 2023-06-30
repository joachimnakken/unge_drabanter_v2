using Newtonsoft.Json;

namespace UngeDrabanter.DtoModels
{
    public class SessionAndUserDto
    {
        [JsonProperty("session")]
        public SessionDto Session { get; set; }

        [JsonProperty("user")]
        public UserDto User { get; set; }
    }
}
