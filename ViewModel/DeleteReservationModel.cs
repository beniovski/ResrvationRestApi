using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.ViewModel
{
    public class DeleteReservationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime StartReservarion { get; set; }
        [Required]
        public DateTime EndReservation { get; set; }
    }
}
