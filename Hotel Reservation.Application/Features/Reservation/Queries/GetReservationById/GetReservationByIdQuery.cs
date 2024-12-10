using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reservation.Queries.GetReservationById
{
    public class GetReservationByIdQuery:IRequest<ReservationDto>
    {
        public int Id { get; set; }
    }
}
