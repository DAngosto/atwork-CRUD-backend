using atwork_CRUD_backend_Domain.Entities;

namespace atwork_CRUD_backend_Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync(int? page, int? size, CancellationToken cancellationToken);
        Task<int> GetAllCountAsync(CancellationToken cancellationToken);
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> AddAsync(Employee employee, bool saveChanges, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Employee employee, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
