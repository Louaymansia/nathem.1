using System.Configuration;
using System.Data.SqlClient;

namespace PublicWorksAndRoads
{
    internal static class Database
    {
        public static SqlConnection CreateConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PublicWorksConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}