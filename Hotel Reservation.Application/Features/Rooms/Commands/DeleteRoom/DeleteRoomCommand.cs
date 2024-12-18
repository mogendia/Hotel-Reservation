﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
