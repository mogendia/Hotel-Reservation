using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reservation.Commands.UpdateReservation
{
    public class UpdateReservationCommand:IRequest<ReservationDto>
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public int GuestsCount { get; set; }
        public double Price { get; set; }
        public int Days { get; set; }
    }
}
