namespace UniversityApiBackend.Models
{
    public class JWTsettings
    {
        public bool ValidateUserSigningKey { get; set; }
        public string UserSigningKey { get; set; } = string.Empty;
        public bool ValidateUser { get; set; } = true;
        public string? ValidUser { get; set; }
        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }
        public bool RequireExpirationTime { get; set; } = true;
        public bool ValidateLifeTime { get; set; } = true;
    }
}
