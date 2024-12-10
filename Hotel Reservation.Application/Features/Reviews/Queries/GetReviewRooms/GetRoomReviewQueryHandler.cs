using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Common.Helper;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reviews.Queries.GetReviewRooms
{
    public class GetRoomReviewQueryHandler(IMapper _mapper,IReviewRepository _repo) :ResponseHandler,
        IRequestHandler<GetRoomReviewQuery, Response<List<ReviewDto>>>
    {
        public async Task<Response<List<ReviewDto>>> Handle(GetRoomReviewQuery request, CancellationToken cancellationToken)
        {
            var response = await _repo.GetRoomsReviews(request.RoomId);
            var reviewList = _mapper.Map<List<ReviewDto>>(response.Reviews);
            var result = Success(reviewList);
            result.Meta = new { reviewList.Count };
            return result;
        }
    }
}
