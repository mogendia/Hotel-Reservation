﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<RoomDto>
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public int MaxOccupancy { get; set; }
    }
}
