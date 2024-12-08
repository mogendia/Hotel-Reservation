using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Application.Helper;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Guests.Queries.GetGuests
{
    public class GetGuestsQuery:IRequest<Response<List<GuestDto>>>
    {
    }
}
