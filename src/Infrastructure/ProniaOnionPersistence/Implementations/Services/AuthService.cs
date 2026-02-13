using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class AuthService : IAuthService
    {

        public readonly UserManager<AppUser> _userManager;
        public readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        public readonly ITokenHandler _tokenHandler;

        public AuthService(
            UserManager<AppUser> userManager,
            IMapper mapper,
            IConfiguration configuration,
            ITokenHandler tokenHandler
            )
        {
            _userManager=userManager;
            _mapper=mapper;
            _configuration=configuration;
            _tokenHandler=tokenHandler;
        }

      
        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            if(await _userManager.Users.AnyAsync(u=>u.UserName==registerDTO.UserName|| u.Email == registerDTO.Email))
            {
                throw  new Exception("User Already Exists");
            }

           var result= await _userManager.CreateAsync(_mapper.Map<AppUser>(registerDTO),registerDTO.Password);

            if (!result.Succeeded)
            {
                StringBuilder strb=new StringBuilder();
                foreach(var error in result.Errors)
                {
                    strb.AppendLine(error.Description);
                }

                throw new Exception(strb.ToString());   
            }
        }

          public async Task<TokenResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            AppUser user= await _userManager.Users.FirstOrDefaultAsync(u=>u.Name==loginDTO.UserNameOrEmail || u.Email==loginDTO.UserNameOrEmail);

            if(user == null)
            {
                throw new Exception("Not Found User");
            }
             bool result = await  _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if (!result)
            {
                await _userManager.AccessFailedAsync(user);
                throw new Exception("Password Incorrect");
            }


              return _tokenHandler.CreateToken(user,15);

        }

    }
}