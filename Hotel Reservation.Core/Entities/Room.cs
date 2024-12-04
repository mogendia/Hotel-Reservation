using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation.Core.Entities
{
    public class Room
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string RoomType { get; set; }
        [Range(150, 1000)]    
        public double PricePerNight { get; set; }
        [Range(1, 10),DefaultValue(1)]
        public int MaxOccupancy { get; set; }
        public bool IsAvailable { get; set; } = true;

    }
}
