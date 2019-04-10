using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationRestApi.Models;

namespace ReservationRestApi.Repository
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly ReservationRestApiContext _rac;
         
        public RoomsRepository()
        {
            _rac = new ReservationRestApiContext();
        }

        public async Task<IEnumerable<Rooms>> GetAllRooms()
        {
              var result = from rooms in _rac.Rooms                        
                           select new Rooms
                           {
                               Id = rooms.Id,
                               Capacity = rooms.Capacity,
                               Number = rooms.Number,                           
                               ReservationDate = _rac.ReservationDate.Where(x => x.RoomId == rooms.Id).ToList(),
                           };
               return result.ToList();
               

          // var result = _rac.Rooms.Include("ReservationDate").ToList();

           return result; 

        }

        public async Task<IEnumerable<Rooms>> GetFreeRoomsInPeriod(DateTime StartDate, DateTime EndDate)
        {
            var query = 
                       from rooms in _rac.Rooms
                       join reservation in _rac.ReservationDate on rooms.Id equals reservation.RoomId
                       where reservation.StartReservarion > EndDate || reservation.EndReservation < StartDate
                       select new Rooms {
                           Id = rooms.Id,
                           Capacity = rooms.Capacity,
                           Number = rooms.Number,                          
                           ReservationDate =  _rac.ReservationDate.Where(x => x.RoomId == rooms.Id ).ToList(),
                       };            

            return query.ToList();
        }

        public async Task<Rooms> GetRoomByID(int id) => await Task.FromResult(_rac.Rooms.Include(a => a.ReservationDate).FirstOrDefault(x => x.Id == id));

        public async Task<Rooms> GetRoomByNumber(int roomNumber) => await Task.FromResult(_rac.Rooms.FirstOrDefault(x => x.Number == roomNumber));

    }
}
