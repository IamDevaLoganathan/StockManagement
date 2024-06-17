using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.DataAccess.Repository.Token;
using StockManagement.Models.DTOModels.Auth;

namespace StockManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Username

            };

             var IdentityUserResult = await userManager.CreateAsync(identityUser,registerDTO.Password);

            if(IdentityUserResult.Succeeded)
            {
                if(registerDTO.Roles.Any() && registerDTO.Roles !=null) 
                {
                    var FinalIdentityResult = await userManager.AddToRoleAsync(identityUser, registerDTO.Roles);
                    
                    if(FinalIdentityResult.Succeeded)
                    {
                        return Ok("Registerd Sucessfully");
                    }
                }
            }

            return BadRequest("Something went Wrong");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.UserName);
            if(user != null)
            {
                var Result = await userManager.CheckPasswordAsync(user, loginDTO.Password);

                if(Result == false)
                {
                    return BadRequest("Incorrect Password");
                }
                else
                {
                    var roles = await userManager.GetRolesAsync(user);

                    /// There we have to generate JWT Token
                    var Token = tokenRepository.CreateJWTToken(user, roles.ToList());
                   
                    return Ok(Token);
                }
            }

            return BadRequest("User Does not Exist!!!");
        }
    }
}
