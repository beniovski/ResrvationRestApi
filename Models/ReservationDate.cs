using System;
using System.Collections.Generic;

namespace ReservationRestApi.Models
{
    public partial class ReservationDate
    {
        public int Id { get; set; }
        public DateTime? StartReservarion { get; set; }
        public DateTime? EndReservation { get; set; }
        public int? RoomId { get; set; }
        public int? UserId { get; set; }

        public Rooms Room { get; set; }
        public Users User { get; set; }
    }
}
