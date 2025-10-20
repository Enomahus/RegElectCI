namespace Infrastructures.Configurations
{
    public class TokenConfiguration
    {
        public string ValidIssuer { get; set; } = "RegElectCI.Web";
        public string? Secret { get; set; }
        public double AccessTokenExpirationMinutes { get; set; } = 10;
        public double RefreshTokenExpirationMinutes { get; set; } = 60 * 24 * 2;
    }
}
