namespace DSN.Common.Authentication
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidAudience { get; set; }
    }
}
