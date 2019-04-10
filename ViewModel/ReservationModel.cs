using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.ViewModel
{
    public class ReservationModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int? Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int? Number { get; set; }

        [Required]
        public DateTime? StartReservarion { get; set; }

        [Required]
        public DateTime? EndReservation { get; set; }


    }
}
