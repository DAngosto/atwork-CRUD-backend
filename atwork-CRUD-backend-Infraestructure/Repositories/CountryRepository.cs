using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atwork_CRUD_backend_Infraestructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Countries.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
