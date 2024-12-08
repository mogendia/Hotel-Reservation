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

namespace Hotel_Reservation.Application.Features.Guests.Queries.GetGuests
{
    public class GetGuestsQueryHandler(IGuestRepository _repo,IMapper _mapper) : ResponseHandler, IRequestHandler<GetGuestsQuery, Response<List<GuestDto>>>
    {
        public async Task<Response<List<GuestDto>>> Handle(GetGuestsQuery request, CancellationToken cancellationToken)
        {
            var guest = await _repo.GetAll();
            var guestMapper = _mapper.Map<List<GuestDto>>(guest);
            var result = Success(guestMapper);
            result.Meta = new { guestMapper.Count };
            return result;
        }
    }
}
