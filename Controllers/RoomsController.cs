using Microsoft.AspNetCore.Mvc;
using ReservationRestApi.Repository;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.Serialization;

namespace ReservationRestApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : Controller
    {
        private readonly IRoomsRepository  _Rr;

        public RoomsController(IRoomsRepository RoomsRepository)
        {
            _Rr = RoomsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var val = await _Rr.GetAllRooms();
                var result = Json(val);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("byDate")]
        public async Task<IActionResult> Get(DateTime startDate, DateTime endDate)
        {
            
            try
            {
                var val = await _Rr.GetFreeRoomsInPeriod(startDate, endDate);
                return Ok(Json(val));
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
                var val = await _Rr.GetRoomByID(id);
                return Ok(Json(val));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }

  
}
