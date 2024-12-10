using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Common.Helper;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Reservation.Application.Features.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandHandler(IGuestRepository _repo,IMapper _mapper) :ResponseHandler, IRequestHandler<UpdateGuestCommand, Response<GuestDto>>
    {
        public async Task<Response<GuestDto>> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            Guest guest = _mapper.Map<Guest>(request);
            var result = await _repo.UpdateGuestAsync(guest);
            return _mapper.Map<Response<GuestDto>>(result);
        }
    }
}
