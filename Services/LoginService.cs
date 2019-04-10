using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationRestApi.Models;
using ReservationRestApi.ViewModel;

namespace ReservationRestApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly IList<UserModel> AppUsers;

        public LoginService()
        {           
            AppUsers = new InMemoryUser().GetAppUsers();
        }
        public UserModel Login(LoginModel User)
        {
            var user =  AppUsers.FirstOrDefault(x => x.Login == User.Username && x.Password == User.Password);
            return user;
        }
    }
}
