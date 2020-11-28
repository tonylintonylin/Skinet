using Core.Entities.Identity;

namespace Core.Interfaces
{
    public class ITokenService
    {
        string CreateToken(AppUser user);
    }
}