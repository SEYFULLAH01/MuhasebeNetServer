using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MuhasebeServer.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuhasebeServer.Persistance.Constans;

namespace MuhasebeServer.Persistance.Configurations
{
    public sealed class UCAFConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
    {
        public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
        {
            builder.ToTable(TableNames.UniformChartOfAccounts);
            builder.HasKey(p => p.Id);
        }
    }   
}