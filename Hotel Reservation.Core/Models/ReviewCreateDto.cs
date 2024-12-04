using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Models
{
    public class ReviewCreateDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
