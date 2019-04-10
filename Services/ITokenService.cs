using ReservationRestApi.Models;
using ReservationRestApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Services
{
    public interface ITokenService
    {
        Task<string> GetToken(UserModel User);
    }
}
 