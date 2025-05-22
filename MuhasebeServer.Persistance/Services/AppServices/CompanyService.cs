using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeServer.Application.Services.AppServices;
using MuhasebeServer.Domain.AppEntities;
using MuhasebeServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeServer.Persistance.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private static readonly Func<AppDbContext, string, Task<Company?>>
            GetCompanyByNameCompiled = EF.CompileAsyncQuery((AppDbContext context, string name) =>
            context.Set<Company>().FirstOrDefault(p => p.Name == name));
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Company?> GetCompanyByName(string name, CancellationToken cancellationToken)
        {
            return await GetCompanyByNameCompiled(_context, name);
        }

        public async Task MigrateCompanyDatabases()
        {
            var companies = await _context.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
