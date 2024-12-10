using Hotel_Reservation.Application.Features.Guests.Commands.CreateGuest;
using Hotel_Reservation.Application.Features.Guests.Commands.DeleteUser;
using Hotel_Reservation.Application.Features.Guests.Commands.UpdateGuest;
using Hotel_Reservation.Application.Features.Guests.Queries.GetGuestById;
using Hotel_Reservation.Application.Features.Guests.Queries.GetGuests;
using Hotel_Reservation.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] CreateGuestCommand command)=>
          Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetGuests() =>
            Ok(await _mediator.Send(new GetGuestsQuery()));

        [HttpGet( "{userId}")]
        public async Task<IActionResult> GetGuestById(string userId) =>
            Ok(await _mediator.Send(new GetGuestsByIdQuery() { Id = userId }));

        [HttpPut]
        public async Task<IActionResult> UpdateGuestInfo([FromBody] UpdateGuestCommand command)=>
            Ok(await _mediator.Send(command));
        
        [HttpDelete]
        public async Task<IActionResult> DeleteGuest(string id)=>
            Ok(await _mediator.Send(new DeleteUserCommand() { Id = id }));
        
    }
    

}
