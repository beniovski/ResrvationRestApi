using System;
using System.Collections.Generic;

namespace ReservationRestApi.Models
{
    public partial class Users
    {
        public Users()
        {
            ReservationDate = new HashSet<ReservationDate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }

        public ICollection<ReservationDate> ReservationDate { get; set; }
    }
}
