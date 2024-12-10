using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Entities
{
    public class Reserve
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public int GuestsCount { get; set; }
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public DateTime CheckOut { get; set; } 
        public int Days { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; } =false;

        public virtual Guest? Guest { get; set; }
        public virtual Room? Room { get; set; }
    }
}
