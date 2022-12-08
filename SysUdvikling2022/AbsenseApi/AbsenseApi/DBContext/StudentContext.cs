using Microsoft.EntityFrameworkCore;
using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AbsenseApi.DBContext
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=tcp:zealand2022absenseserver.database.windows.net,1433;Initial Catalog=Zealand2022AbsenseDB;Persist Security Info=False;User ID=admin1234;Password=Admin4321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n");
        }
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options) { }

        public StudentContext()
        {
        }

        public DbSet<Student> students { get; set; }
    }
}
