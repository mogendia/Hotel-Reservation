using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Models;
using Hotel_Reservation.Core.Repositories;
using MediatR;

namespace Hotel_Reservation.Application.Features.Reservation.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler(IReservationRepository _repo) : IRequestHandler<DeleteReservationCommand, bool>
    {
        public async Task<bool> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
