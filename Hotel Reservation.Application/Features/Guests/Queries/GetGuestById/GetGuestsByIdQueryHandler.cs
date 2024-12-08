using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Helper;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Guests.Queries.GetGuestById
{
    public class GetGuestsByIdQueryHandler(IGuestRepository _repo,IMapper _mapper) :ResponseHandler, IRequestHandler<GetGuestsByIdQuery, Response<GuestDto>>
    {
        public async Task<Response<GuestDto>> Handle(GetGuestsByIdQuery request, CancellationToken cancellationToken)
        {
            var guest = await _repo.GetById(request.Id);
            var guestMapper = _mapper.Map<GuestDto>(guest);
            var result = Success(guestMapper);
            result.Data = guestMapper; // add
            return result;
        }
    }
}
