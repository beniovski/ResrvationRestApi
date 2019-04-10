using ReservationRestApi.Models;
using ReservationRestApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Services
{
    public interface ILoginService
    {
       UserModel Login(LoginModel User);
    }
}
