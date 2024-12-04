using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Models
{
    public class RoomReview
    {
        public List<ReviewDto> Reviews { get; set; }
        public int AverageRating { get; set; }
    }
}
