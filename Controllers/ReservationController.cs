using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationRestApi.Models;
using ReservationRestApi.Services;
using ReservationRestApi.ViewModel;
using System;
using System.Threading.Tasks;

namespace ReservationRestApi.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]     
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationServie;
       
        public ReservationController(IReservationService reservationService)
        {
            _reservationServie = reservationService;
        }
        
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody]ReservationModel reservationModel)
        {
            IActionResult response = BadRequest();
            try
            {               
                if (ModelState.IsValid)
                {
                    await _reservationServie.MakeReservation(reservationModel);
                    response = Ok();                  
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return response;
        }
        
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteReservation(DeleteReservationModel deleteReservationModel)
        {
            IActionResult response = BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    await _reservationServie.DeleteReservation(deleteReservationModel);
                    response = Ok("delete success");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            return response;
        }
        
    }
} 
