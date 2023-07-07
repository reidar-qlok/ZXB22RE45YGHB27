using ZXB22RE45YGHB27.Models;
using Microsoft.EntityFrameworkCore;

namespace ZXB22RE45YGHB27.Data
{
    internal sealed class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectList> ProjectLists { get; set; }
        public DbSet<Project> Projects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder

        .UseSqlServer("Server=REIDAR10PRO\\SQL2K19;Database=ZXB22RE45YGHB27;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
        //.UseSqlServer("Server=tcp:rndbserver.database.windows.net,1433;Initial Catalog=AXB22Z45YGHA;Persist Security Info=False;User ID=rndbadmin;Password=reidar;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Employee[] employeeToSeed = new Employee[6];
            for (int i = 1; i <= 6; i++)
            {
                employeeToSeed[i - 1] = new Employee
                {
                    EmployeeId = i,
                    FirstMidName= $"Albert{i}",
                    LastName = $"Nosteen{i}"
                };
            }
            modelBuilder.Entity<ProjectList>()
                .HasOne(p => p.Employees)
                .WithMany(p => p.ProjectLists)
                .HasForeignKey(pl => pl.FK_EmployeeId);

            modelBuilder.Entity<ProjectList>()
                .HasOne(p => p.Projects)
                .WithMany(p => p.ProjectLists)
                .HasForeignKey(pl => pl.FK_ProjectId);
        }
    }
}
