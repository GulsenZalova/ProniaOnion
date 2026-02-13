namespace ProniaOnion.src.Application
{
    public interface IAuthService
    {
        
        Task RegisterAsync(RegisterDTO registerDTO);
        Task<TokenResponseDTO> LoginAsync (LoginDTO loginDTO);
    }
}