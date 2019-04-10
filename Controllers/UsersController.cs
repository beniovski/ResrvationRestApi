using Microsoft.AspNetCore.Mvc;
using ReservationRestApi.Repository;
using System.Threading.Tasks;
using System;
using ReservationRestApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace ReservationRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersContoller : Controller  
    {
        private readonly IUserRepository _Ur;

        public UsersContoller(IUserRepository userRepository)
        {
            _Ur = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var val = await Task.FromResult(_Ur.GetAllUsers());
                return Json(val);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
           
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await Task.FromResult(_Ur.GetUserById(id));
                return Ok(Json(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);           
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _Ur.DeleteUser(id);
           return Ok("Deletion ok");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users User)
        {            
            await _Ur.AddUser(User);
            return Ok(User);   
        }

    }
}
