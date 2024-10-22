using atwork_CRUD_backend_Domain.Entities;

namespace atwork_CRUD_backend_Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> AddAsync(User user, bool saveChanges, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(User user, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
