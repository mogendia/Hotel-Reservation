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

namespace Hotel_Reservation.Application.Features.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdHandler(IMapper _mapper, IRoomRepository _repo) :ResponseHandler, IRequestHandler<GetRoomByIdQuery, Response<RoomDto>>
    {
        public async Task<Response<RoomDto>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _repo.GetById(request.Id);
            var roomList = _mapper.Map<RoomDto>(room);
            var result = Success(roomList);
            return result;
        }
    }
}
