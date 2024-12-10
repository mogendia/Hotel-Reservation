using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Application.Common.Helper;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reviews.Queries.GetReviewRooms
{
    public class GetRoomReviewQuery:IRequest<Response<List<ReviewDto>>>
    {
        public int RoomId { get; set; }
    }
}
