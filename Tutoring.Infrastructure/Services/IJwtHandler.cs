using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}
