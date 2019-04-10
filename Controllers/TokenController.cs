using Microsoft.AspNetCore.Mvc;
using ReservationRestApi.Repository;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ReservationRestApi.Services;
using ReservationRestApi.Models;
using ReservationRestApi.ViewModel;

namespace ReservationRestApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly ILoginService _loginService;

        private readonly ITokenService _tokenService;

        //private readonly IReservationService _reservationService;

        public TokenController(ILoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }
     
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginModel login)
        {          
            try
            {
                //String tokenString;
                Task<string> tokenString = null;
                if (ModelState.IsValid)
                {
                    var user = _loginService.Login(login);
                    tokenString = await Task.FromResult(_tokenService.GetToken(user));                  
                }
                return Ok(new { token = tokenString });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    
      
    }
}
