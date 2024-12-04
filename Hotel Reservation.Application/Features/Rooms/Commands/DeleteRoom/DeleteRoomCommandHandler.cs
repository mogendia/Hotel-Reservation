using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler(IRoomRepository _repo) : IRequestHandler<DeleteRoomCommand, bool>
    {
        public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
