using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace student.Infrastructure.Context
{
    public class StudentContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public StudentContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
