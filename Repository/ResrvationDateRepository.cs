using ReservationRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Repository
{
    public class ResrvationDateRepository : IReservationDateRepository
    {
        private readonly ReservationRestApiContext _rac;

        public ResrvationDateRepository()
        {
            _rac = new ReservationRestApiContext();
        }

        public async Task AddReservationDate(DateTime startReservation, DateTime endReservartion, int roomNumber, int userId)
        {
            var getRoom = _rac.Rooms.FirstOrDefault(x => x.Number == roomNumber);
            var reservartion = new ReservationDate()
            {
                StartReservarion = startReservation,
                EndReservation = endReservartion,
                RoomId = getRoom.Id,
                UserId = userId
            };
            await _rac.ReservationDate.AddAsync(reservartion);
            await _rac.SaveChangesAsync();
        }

        public async Task DeleteReservationDate(DateTime startReservation, DateTime endReservartion, int roomNumber, int userId)
        {
            var getRoom = _rac.Rooms.FirstOrDefault(x => x.Number == roomNumber);
            var reservartion = _rac.ReservationDate.FirstOrDefault(x => x.RoomId == getRoom.Id && x.StartReservarion == startReservation && x.EndReservation == endReservartion);
            await Task.FromResult(_rac.ReservationDate.Remove(reservartion));
            await _rac.SaveChangesAsync();
        }

    }
}
 