using atwork_CRUD_backend_Domain.Services;
using atwork_CRUD_backend_Infraestructure.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace atwork_CRUD_backend_Infraestructure.Services
{
    public class PasswordService: IPasswordService
    {
        private readonly string _secretKey;

        public PasswordService(IOptions<JwtSettings> jwtSettings)
        {
            _secretKey = jwtSettings.Value.Secret;
        }

        public string GeneratePasswordHash(string password)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey)))
            {
                var salt = GenerateSalt();
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                var combinedBytes = Combine(passwordBytes, salt);
                var hashBytes = hmac.ComputeHash(combinedBytes);

                return $"{Convert.ToBase64String(hashBytes)}:{Convert.ToBase64String(salt)}";
            }
        }

        public bool ValidatePassword(string password, string hashedPassword)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey)))
            {
                var parts = hashedPassword.Split(':');
                var storedHash = Convert.FromBase64String(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);

                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var combinedBytes = Combine(passwordBytes, salt);
                var computedHash = hmac.ComputeHash(combinedBytes);

                return storedHash.SequenceEqual(computedHash);
            }
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private byte[] Combine(byte[] first, byte[] second)
        {
            var combined = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, combined, 0, first.Length);
            Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);
            return combined;
        }
    }
}
