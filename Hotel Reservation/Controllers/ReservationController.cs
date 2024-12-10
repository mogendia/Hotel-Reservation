using Hotel_Reservation.Application.Features.Reservation.Commands.CreateReservation;
using Hotel_Reservation.Application.Features.Reservation.Commands.DeleteReservation;
using Hotel_Reservation.Application.Features.Reservation.Commands.UpdateReservation;
using Hotel_Reservation.Application.Features.Reservation.Queries.GetAllReservations;
using Hotel_Reservation.Application.Features.Reservation.Queries.GetReservationById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Customers")]

    public class ReservationController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetReservations() =>
            Ok(await _mediator.Send(new GetAllReservationsQuery ()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id) =>
            Ok(await _mediator.Send(new GetReservationByIdQuery() {Id = id }));

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)=>
            Ok(await _mediator.Send(command));
        [HttpPut]
        public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationCommand command)=>
            Ok(await _mediator.Send(command));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)=>
            Ok(await _mediator.Send(new DeleteReservationCommand() { Id = id }));
    }
}
