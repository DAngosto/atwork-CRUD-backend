using atwork_CRUD_backend_Domain.Entities;

namespace atwork_CRUD_backend_Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync(CancellationToken cancellationToken);
    }
}
