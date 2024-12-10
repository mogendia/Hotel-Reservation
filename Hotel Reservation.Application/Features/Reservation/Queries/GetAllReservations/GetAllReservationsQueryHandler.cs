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

namespace Hotel_Reservation.Application.Features.Reservation.Queries.GetAllReservations
{
    public class GetAllReservationsQueryHandler(IMapper _mapper,IReservationRepository _repo) : ResponseHandler, IRequestHandler<GetAllReservationsQuery, Response<List<ReservationDto>>>
    {
        public async Task<Response<List<ReservationDto>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var room = await _repo.GetAll();
            var roomList = _mapper.Map<List<ReservationDto>>(room);
            var result = Success(roomList);
            result.Meta = new { roomList.Count };
            return result;
        }
    }
}
