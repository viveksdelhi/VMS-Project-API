namespace VMS_Project_API.AppCode
{
    public class GlobalModel
    {
        public static string JWTSecret { get; set; } = "1234567890123456789123456789012345678912345678901234567890";
        public static string JWTValidIssuer { get; set; } = "admin";
        public static string JWTValidAudience { get; set; } = "admin";
        public static string WUserId { get; set; } = "2000241495";//Convert.ToString(Environment.GetEnvironmentVariable("WUserId"));
        public static string WPassword { get; set; } = "nB$yvp4U";
    }
}
