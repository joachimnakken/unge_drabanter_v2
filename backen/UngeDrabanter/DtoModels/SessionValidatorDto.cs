namespace UngeDrabanter.DtoModels
{
    public class SessionValidatorDto
    {
        public string Provider { get; set; } = string.Empty;
        public string ProviderAccountId { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
