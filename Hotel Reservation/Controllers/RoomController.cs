using Hotel_Reservation.Application.Features.Rooms.Commands.CreateRoom;
using Hotel_Reservation.Application.Features.Rooms.Commands.DeleteRoom;
using Hotel_Reservation.Application.Features.Rooms.Commands.UpdateRoom;
using Hotel_Reservation.Application.Features.Rooms.Queries.GetRoomById;
using Hotel_Reservation.Application.Features.Rooms.Queries.GetRoomList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Bearer",Policy = "SuperAdmins")]
    public class RoomController(IMediator _mediaor) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var response = await _mediaor.Send(new GetRoomListQuery());
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var response = await _mediaor.Send(new GetRoomByIdQuery() { Id = id });
            return Ok(response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Customers")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            var response = await _mediaor.Send(command);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromBody] UpdateRoomCommand command)
        {
            var response = await _mediaor.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var response = await _mediaor.Send(new DeleteRoomCommand() { Id = id });
            return Ok(response);
        }
            
    }
}
