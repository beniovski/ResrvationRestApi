using ReservationRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsers();

        Task<Users> GetUserById(int id);

        Task DeleteUser(int id);

        Task AddUser(Users user);

        Task<int> AddUserReturnUserId(Users user);

        Task<Users> GetUserByNameAndLastName(string name, string lastname);
    }
}
