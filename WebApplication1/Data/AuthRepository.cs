using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Data
{
    public class AuthRepository: IAuthRepository
    {

private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context; //constructor
        }



        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username); // first or default returns the element searched or if not found null.

            if(user == null)
                return null;

             if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
             return null;

             return user;
            
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
                 using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
           {
               
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

               for(int i = 0; i < computedHash.Length; i++)
               {
                   if(computedHash[i] != passwordHash[i]) return false;
               }
           }

           return true;
        }



        public async Task<User> Register(User user, string password)
        {
               byte[] passwordHash, passwordSalt;
               CreatePasswordHash(password,out passwordHash,out passwordSalt); // out means it is passing as a reference


               user.PasswordHash = passwordHash;
               user.PasswordSalt = passwordSalt;

               await _context.Users.AddAsync(user);
               await _context.SaveChangesAsync();

               return user;
        }






        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using (var hmac = new System.Security.Cryptography.HMACSHA512())
           {
               passwordSalt = hmac.Key; // randomly generated key. Effectively, the salt key unlocks the hash and the hash then unlocks the password
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
        }




        public async Task<bool> UserExists(string username)
        {
              if(await _context.Users.AnyAsync(x =>x.Username == username))
              return true;

              return false;
        }
    }
}
