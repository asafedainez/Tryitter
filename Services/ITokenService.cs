using Tryitter.Models;

namespace Tryitter.Services
{
    public interface ITokenService
    {
        public string GenerateToken(string key, string issuer, UserModel user);
    }
}
