using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MuhasebeServer.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeServer.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString = "";

        public CompanyDbContext(string companyıd, Company company = null)
        {
            if (company != null)
            {
                if (String.IsNullOrEmpty(company.ServerUserId))
                    ConnectionString = $"" +
                        $"Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"Integrated Security=True;" +
                        $"Connect Timeout=30;" +
                        $"Encrypt=False;" +
                        $"TrustServerCertificate=False;" +
                        $"ApplicationIntent=ReadWrite;" +
                        $"MultiSubnetFailover=False";
                else
                    ConnectionString = $"" +
                        $"Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"User Id={company.ServerUserId};" +
                        $"Password={company.ServerPassword};" +
                        $"Integrated Security=True;" +
                        $"Connect Timeout=30;" +
                        $"Encrypt=False;" +
                        $"TrustServerCertificate=False;" +
                        $"ApplicationIntent=ReadWrite;" +
                        $"MultiSubnetFailover=False";
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            private readonly AppDbContext dbContext;

            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext("");
            }
        }
    }
}