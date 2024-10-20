namespace atwork_CRUD_backend_Domain.Services
{
    public interface IPasswordService
    {
        string GeneratePasswordHash(string password);
        bool ValidatePassword(string password, string hashedPassword);
    }
}
