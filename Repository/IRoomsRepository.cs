using ReservationRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Repository
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<Rooms>> GetAllRooms();

        Task<Rooms> GetRoomByID(int id);

        Task<IEnumerable<Rooms>> GetFreeRoomsInPeriod(DateTime StartDate, DateTime EndTime);

        Task<Rooms> GetRoomByNumber(int roomNumber);
    }
}
