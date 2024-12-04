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

namespace Hotel_Reservation.Application.Features.Reviews.Command.AddReview
{
    public class AddReviewCommandHandler(IMapper _mapper,IReviewRepository _repo) : IRequestHandler<AddReviewCommand, Review>
    {
        public async Task<Review> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
           ReviewCreateDto reviewDto = _mapper.Map<ReviewCreateDto>(request);
           return await _repo.AddRoomReview(reviewDto);
            
        }
    }
}
