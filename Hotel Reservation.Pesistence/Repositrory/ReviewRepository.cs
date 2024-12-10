using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using Hotel_Reservation.Core.Repositories.Repositrory;
using Hotel_Reservation.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Persistence.Repositrory;
public class ReviewRepository(ApplicationDbContext context) : GenericRepository<Review>(context), IReviewRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Review> AddRoomReview(ReviewCreateDto reviewDto,int rating)
    {
      
        var roomExists = await _context.Rooms.AnyAsync(r => r.Id == reviewDto.RoomId);
        if (!roomExists)
        {
            throw new Exception("Room does not exist.");
        }
        if (rating < 1 || rating > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");
        }
        Review review = new()
        {
            RoomId = reviewDto.RoomId,
            Rating = reviewDto.Rating,
            Comment = reviewDto.Comment
        };


        var result = await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<RoomReview> GetRoomsReviews(int roomId)
    {
        var reviews = await _context.Reviews
            .Where(x => x.RoomId == roomId)
            .Select(x => new ReviewDto
            {
                RoomId = x.RoomId,
                Rating = x.Rating,
                Comment = x.Comment
            }).ToListAsync();

        var averageRating = reviews.Count != 0 ? (int)reviews.Average(x => x.Rating) : 0;

        return new RoomReview
        {
            Reviews = reviews,
            AverageRating = averageRating
        };
    }

    
}

    