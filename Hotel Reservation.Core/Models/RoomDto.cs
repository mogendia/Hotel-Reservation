using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Models
{
    public class RoomDto
    {
        private int Id { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public int MaxOccupancy { get; set; }
    }
}
