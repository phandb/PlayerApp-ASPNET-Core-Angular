using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerApp.API.Models;

namespace PlayerApp.API.Data
{
    public interface IPlayerRepository
    {
         void Add<T>(T entity) where T: class;

         void Delete<T>(T entity) where T: class;

         Task<bool> SaveAll();

         Task<IEnumerable<User>> GetUsers();

         Task<User> GetUser(int id);

         Task<Photo> GetPhoto(int id);
    }
}