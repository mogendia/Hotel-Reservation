using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Models;
using MediatR;

namespace Hotel_Reservation.Application.Features.Guests.Commands.CreateGuest
{
    public class CreateGuestCommand : IRequest<GuestDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get; set; }
        //[RegularExpression(@"^(?:\+20|0)(1[0-9]{9}|2[0-9]{7}|[3-9][0-9]{7})$",
        // ErrorMessage = "Invalid Egyptian phone number format.")]
        public string? PhoneNumber { get; set; }
    }
}
