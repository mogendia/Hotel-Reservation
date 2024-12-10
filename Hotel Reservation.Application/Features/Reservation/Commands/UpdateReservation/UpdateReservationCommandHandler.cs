using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reservation.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler(IReservationRepository _repo,IMapper _mapper) : IRequestHandler<UpdateReservationCommand, ReservationDto>
    {
        public async Task<ReservationDto> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            Reserve reserve = _mapper.Map<Reserve>(request);
            var room = await _repo.UpdateAsync(reserve);
            var roomReserve = _mapper.Map<ReservationDto>(room);
            return roomReserve;
        }
    }
}
