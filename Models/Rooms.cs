using System;
using System.Collections.Generic;

namespace ReservationRestApi.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            ReservationDate = new HashSet<ReservationDate>();
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public int? Capacity { get; set; }

        public ICollection<ReservationDate> ReservationDate { get; set; }
    }
}
