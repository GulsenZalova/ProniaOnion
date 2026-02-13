using ProniaOnion.src.Domain;

namespace ProniaOnion.src.Application
{
    public interface ITokenHandler
    {
        
      TokenResponseDTO  CreateToken(AppUser user, int minutes);
    }
}