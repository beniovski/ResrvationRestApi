using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Repository
{
    public interface IReservationDateRepository
    {
        Task AddReservationDate(DateTime startReservation, DateTime endReservartion, int roomNumber, int userId);

        Task DeleteReservationDate(DateTime startReservation, DateTime endReservartion, int roomNumber, int userId);
    }
}
