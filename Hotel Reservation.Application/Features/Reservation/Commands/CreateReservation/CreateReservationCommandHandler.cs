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

namespace Hotel_Reservation.Application.Features.Reservation.Commands.CreateReservation
{
    public class CreateReservationCommandHandler(IReservationRepository _repo,IMapper _mapper) : IRequestHandler<CreateReservationCommand, ReservationDto>
    {
        public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<Reserve>(request);
            var roomReserve = await _repo.CreateAsync(room);
            var result = _mapper.Map<ReservationDto>(roomReserve);
            return result;
        }
    }
}
