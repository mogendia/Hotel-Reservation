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

namespace Hotel_Reservation.Application.Features.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandHandler(IGuestRepository _repo, IMapper _mapper) : IRequestHandler<CreateGuestCommand, GuestDto>
    {
        public async Task<GuestDto> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            Guest guest = _mapper.Map<Guest>(request);
            var result = await _repo.CreateAsync(guest);
            return _mapper.Map<GuestDto>(result);
            
        }
    }
}
