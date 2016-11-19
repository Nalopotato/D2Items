using System.Configuration;

namespace D2Items
{
    public class Queries
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["D2ConnectionString"].ConnectionString;
        }
    }
}