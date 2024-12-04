using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Entities
{
    public class Review
    {
        public int Id { get; set; }
        //public int GuestId { get; set; }
        public int RoomId { get; set; }
        [Range(1, 5),DefaultValue(1)]
        
        public int Rating { get; set; } 
        public string? Comment { get; set; }
        public virtual Room? Room { get; set; }
    }
}
