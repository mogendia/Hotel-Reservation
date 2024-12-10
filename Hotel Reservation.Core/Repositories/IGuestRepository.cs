using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;

namespace Hotel_Reservation.Core.Repositories
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
        Task<Guest> GetGuestRepoById(string id);
        Task<Guest> UpdateGuestAsync(Guest guest);
        Task<bool> DeleteAsync(string id);
    }
}
