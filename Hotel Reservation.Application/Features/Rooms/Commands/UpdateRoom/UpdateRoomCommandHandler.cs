
using AutoMapper;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler(IMapper _mapper , IRoomRepository _repo) : IRequestHandler<UpdateRoomCommand, RoomDto>
    {
        public async Task<RoomDto> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var rooms = _mapper.Map<Room>(request);
            var result = await _repo.UpdateAsync(rooms);
            return _mapper.Map<RoomDto>(result);
        }
    }
}
