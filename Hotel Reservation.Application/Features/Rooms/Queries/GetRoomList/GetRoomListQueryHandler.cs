using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Common.Helper;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Queries.GetRoomList
{
    public class GetRoomListQueryHandler(IMapper _mapper,IRoomRepository _repo) :ResponseHandler, IRequestHandler<GetRoomListQuery, Response<List<RoomDto>>>
    {
        public async Task<Response<List<RoomDto>>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _repo.GetAll();
            var roomList = _mapper.Map<List<RoomDto>>(rooms);
            var result = Success(roomList);
            result.Meta = new { roomList.Count };
            return result;
        }
    }
}
