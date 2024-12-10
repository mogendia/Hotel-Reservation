using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public int GuestsCount { get; set; }
        public double Price { get; set; }
        public int Days { get; set; }

    }
}
