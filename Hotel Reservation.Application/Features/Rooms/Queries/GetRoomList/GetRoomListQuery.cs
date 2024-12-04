using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Application.Helper;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Queries.GetRoomList
{
    public class GetRoomListQuery : IRequest<Response<List<RoomDto>>>
    {
    }
}
