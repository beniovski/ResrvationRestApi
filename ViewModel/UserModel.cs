using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.ViewModel
{
    public class UserModel
    {

        public string Login { get; set; }
        public string Password { get; set; }       
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public UserModel(string login, string password, string email )
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
