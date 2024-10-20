using atwork_CRUD_backend_Domain.Entities;

namespace atwork_CRUD_backend_Domain.Services
{
    public interface ITokenProviderService
    {
        string Create(User user);
    }
}
