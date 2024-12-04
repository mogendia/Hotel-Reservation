using Hotel_Reservation.Application.Features.Reviews.Command.AddReview;
using Hotel_Reservation.Application.Features.Reviews.Queries.GetReviewRooms;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatReview([FromBody] AddReviewCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetReviews(int id)
        {
            var response = await _mediator.Send(new GetRoomReviewQuery() { RoomId = id });
            return Ok(response);
        }
    }
}
