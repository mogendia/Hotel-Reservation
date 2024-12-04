using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Repositories;
using Hotel_Reservation.Persistence.Data;
using Microsoft.EntityFrameworkCore;
namespace Hotel_Reservation.Core.Repositories.Repositrory
{
    public class GenericRepository<T>(ApplicationDbContext _context) : IGenericRepository<T> where T : class
    {
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task <List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
