using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayerApp.API.Models;

namespace PlayerApp.API.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        // Implement methods of interface
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetPhoto(int id)
        { 
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos ).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}