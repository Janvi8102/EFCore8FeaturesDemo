using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DbConnectionFactory
    {
        public static string Create(string databaseName)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "SF-LAP-725\\SQLEXPRESS",
                InitialCatalog = databaseName,
                Encrypt = false,
                TrustServerCertificate = true,
                IntegratedSecurity = true,
                MultiSubnetFailover = false,
                MultipleActiveResultSets = true,
                ApplicationIntent = ApplicationIntent.ReadWrite
            };

            Console.WriteLine($"Generated connection string: {builder.ConnectionString}");

            return builder.ConnectionString;
        }
    }
}
