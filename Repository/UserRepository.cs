using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationRestApi.Models;

namespace ReservationRestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ReservationRestApiContext _rac; 

        public UserRepository()
        {
            _rac = new ReservationRestApiContext();
        }

        public async Task AddUser(Users user)
        {
           await _rac.Users.AddAsync(user);
           await _rac.SaveChangesAsync();
        }

        public async Task<int> AddUserReturnUserId(Users user)
        {
            await _rac.Users.AddAsync(user);
            await _rac.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteUser(int id)
        {
            var user = await  Task.FromResult(_rac.Users.First(a => a.Id == id));
            await Task.FromResult(_rac.Users.Remove(user));
            await _rac.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUsers() => await Task.FromResult(_rac.Users.ToList());         

        public async Task<Users> GetUserById(int id) => await Task.FromResult((Users)_rac.Users.FirstOrDefault(a => a.Id == id));
        
        public async Task<Users> GetUserByNameAndLastName(string name, string lastname) => 
               await Task.FromResult(_rac.Users.First(a => a.Name == name && a.LastName == lastname));
        


    }
}
