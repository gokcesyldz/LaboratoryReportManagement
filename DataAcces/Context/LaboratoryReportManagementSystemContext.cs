using DataAcces.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataAcces.Context
{
    public class LaboratoryReportManagementSystemContext : DbContext
    {

            public LaboratoryReportManagementSystemContext()
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer("Server=LAPTOP-2N4IBTA8\\MSSQLSERVER01;Database=LaborantDb;Trusted_Connection=True;TrustServerCertificate=true;");
            }

        public DbSet<Laborant> Laborants { get; set; }
        public DbSet<Report> Reports { get; set; }

    }
}
