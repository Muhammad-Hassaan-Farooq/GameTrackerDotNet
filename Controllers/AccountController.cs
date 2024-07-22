using api.Accounts.DTO;
using api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user =await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==loginDto.Username.ToLower());

            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded) return Unauthorized("Username and/or password invalid");

            return Ok(new NewUserDto{
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDTO registerDTO){
            try
            {
                if(!ModelState.IsValid){
                    BadRequest(ModelState);
                }
                var user = new AppUser
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email
                };
                var result = await _userManager.CreateAsync(user, registerDTO.Password);
                if(result.Succeeded){

                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if(roleResult.Succeeded){
                    return Ok(new NewUserDto{
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    });
                    }
                    else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else{
                    return StatusCode(500, result.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}