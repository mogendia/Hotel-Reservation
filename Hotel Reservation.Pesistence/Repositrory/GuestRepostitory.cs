using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Repositories;
using Hotel_Reservation.Core.Repositories.Repositrory;
using Hotel_Reservation.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Persistence.Repositrory
{
    public class GuestReposititory : GenericRepository<Guest>,IGuestRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestReposititory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Guest>> GetGuest()
        {
            return await _context.Guests.ToListAsync();
        }
        public async Task<Guest> GetGuestById(string id)
        {
            return await _context.Guests.FindAsync(id);
        }
        public async Task<Guest> CreateGuest(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
            return guest;
        }
        public async Task<int> UpdateGuest(Guest guest)
        {
            var edit = await _context.Guests.FirstOrDefaultAsync(x => x.Id == guest.Id);
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
            return guest.Id;
        }
        public async Task<bool> DeleteGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            _context.Guests.Remove(entity: guest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
