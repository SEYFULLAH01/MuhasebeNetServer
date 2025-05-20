using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuhasebeServer.Domain.AppEntities;
using MuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeServer.Persistance.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole,string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }
    }
}
