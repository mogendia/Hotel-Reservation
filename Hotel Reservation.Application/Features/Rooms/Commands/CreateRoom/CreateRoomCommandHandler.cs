using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Features.Rooms.Queries.GetRoomList;
using Hotel_Reservation.Application.Helper;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler(IMapper _mapper, IRoomRepository _repo) :  IRequestHandler<CreateRoomCommand, RoomDto>
    {
        public async Task<RoomDto> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            Room rooms = _mapper.Map<Room>(request);
            var result = await _repo.CreateAsync(rooms);
            return _mapper.Map<RoomDto>(result);
        }
    }
}
