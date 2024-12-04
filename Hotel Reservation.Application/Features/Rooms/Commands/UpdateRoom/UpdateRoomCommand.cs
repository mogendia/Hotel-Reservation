using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Application.Helper;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest<RoomDto>
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public int MaxOccupancy { get; set; }
    }   
}
