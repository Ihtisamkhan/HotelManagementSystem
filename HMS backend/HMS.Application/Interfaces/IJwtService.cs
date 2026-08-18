using HMS.Domain.Entities;

namespace HMS.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user, IList<string> roles);
    }
}
