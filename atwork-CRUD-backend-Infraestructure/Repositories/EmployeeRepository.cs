using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace atwork_CRUD_backend_Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Employees.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> AddAsync(Employee employee, bool saveChanges, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            if (saveChanges)
                return (await _context.SaveChangesAsync(cancellationToken)) > 0;
            return true;
        }

        public async Task<bool> UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is not null)
            {
                _context.Employees.Remove(employee);
                return (await _context.SaveChangesAsync(cancellationToken)) > 0;
            }
            return false;
        }
    }
}
