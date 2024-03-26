namespace RandomUser.Web.Utility
{
    public class SD
    {
        public static string RandomUserAPIBase { get; set; }
        public static string HealthCheckAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum ContentType
        {
            Json
           
        }
    }
}
