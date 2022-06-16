using AutoMapper;
using FoodZone.Models.Security;
using FoodZone.Services.DTO;
using FoodZone.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodZone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAuthServices _authServices;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager, IMapper mapper, IAuthServices authServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _authServices = authServices;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<Account>(accountDTO);
            user.UserName = accountDTO.Email;
            var result = await _userManager.CreateAsync(user, accountDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return BadRequest(ModelState);
            }

            return Accepted();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authServices.ValidateUser(loginUserDTO))
            {
                return Unauthorized(loginUserDTO);
            }

            return Accepted(new {Token = await _authServices.CreateToken()});
        }
    }
}
