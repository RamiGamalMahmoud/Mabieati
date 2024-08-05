using Microsoft.EntityFrameworkCore;

namespace Mabieati.Data
{
    public class AppDbContextFactory
    {
        private readonly string _connectionString;

        public AppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AppDbContext CreateDbContext()
        {
            return new AppDbContext(new DbContextOptionsBuilder()
                .UseSqlite(_connectionString)
                .Options); ;
        }
    }
}
