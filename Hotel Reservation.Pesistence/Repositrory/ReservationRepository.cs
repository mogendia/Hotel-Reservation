using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Repositories;
using Hotel_Reservation.Core.Repositories.Repositrory;
using Hotel_Reservation.Persistence.Data;

namespace Hotel_Reservation.Persistence.Repositrory
{
    public class ReservationRepository(ApplicationDbContext context) : GenericRepository<Reserve>(context), IReservationRepository
    {
        private readonly ApplicationDbContext _context = context;
    }
}
