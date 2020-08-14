using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
   public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class; // add a type of t where it could be a user or photo and constraint this to a type of class. Saves having two functions for adding a user or photo
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);
    }
}
