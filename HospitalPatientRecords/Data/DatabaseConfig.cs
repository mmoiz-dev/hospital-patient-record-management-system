using Microsoft.EntityFrameworkCore;
using System.IO;

namespace HospitalPatientRecords.Data
{
    public static class DatabaseConfig
    {
        private static string DbPath = Path.Combine(Application.StartupPath, "HospitalDB.db");

        public static DbContextOptions<DatabaseContext> GetOptions()
        {
            return new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite($"Data Source={DbPath}")
                .Options;
        }

        public static void InitializeDatabase()
        {
            using (var context = new DatabaseContext(GetOptions()))
            {
                context.Database.EnsureCreated();
            }
        }
    }
} 