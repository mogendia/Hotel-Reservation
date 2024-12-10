using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;

namespace Hotel_Reservation.Core.Repositories
{
    public interface IReservationRepository : IGenericRepository<Reserve>
    {
    }
}
