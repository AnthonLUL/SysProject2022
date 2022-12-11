using Microsoft.EntityFrameworkCore;
using StudentLibrary;

namespace AbsenseApi.DBContext
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=tcp:zealand2022absenseserver.database.windows.net,1433;Initial Catalog=Zealand2022AbsenseDB;Persist Security Info=False;User ID=admin1234;Password=Admin4321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options) { }

        public StudentContext()
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
