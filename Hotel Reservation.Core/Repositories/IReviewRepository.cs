using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;

namespace Hotel_Reservation.Core.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<RoomReview> GetRoomsReviews(int roomId);
        Task<Review>AddRoomReview(ReviewCreateDto reviewDto);
    }
}
