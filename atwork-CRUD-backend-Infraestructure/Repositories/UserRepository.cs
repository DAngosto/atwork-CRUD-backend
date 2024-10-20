using atwork_CRUD_backend_Domain.Entities;
using atwork_CRUD_backend_Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace atwork_CRUD_backend_Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
        }

        public async Task<bool> AddAsync(User user, bool saveChanges, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            if (saveChanges)
                return (await _context.SaveChangesAsync(cancellationToken)) > 0;
            return true;
        }

        public async Task<bool> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                return (await _context.SaveChangesAsync(cancellationToken)) > 0;
            }
            return false;
        }
    }
}
