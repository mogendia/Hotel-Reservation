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
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> CreateRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room; 
        }
        public async Task<int> UpdateRoom(Room room)
        {
            var edit = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == room.Id);
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room.Id;
        }
        public async Task<bool> DeleteRoom (int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
