namespace WebAPI.Options
{
    public class WebAPIOptions
    {
        public string ApiDomain { get; set; }
        public string[] AllowedOrigins { get; set; } = [];
    }
}
