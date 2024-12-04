using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reviews.Command.AddReview
{
    public class AddReviewCommand : IRequest<Review>
    {
        public int RoomId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
