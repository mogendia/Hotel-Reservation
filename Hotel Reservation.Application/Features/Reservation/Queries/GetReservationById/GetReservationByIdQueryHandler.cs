using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reservation.Queries.GetReservationById
{
    public class GetReservationByIdQueryHandler(IMapper _mapper,IReservationRepository _repo) : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _repo.GetById(request.Id);
            return _mapper.Map<ReservationDto>(room);
        }
    }
}
