using ReservationRestApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationRestApi.Models
{
    public class InMemoryUser
    {
        IList<UserModel> UserModel;

        public InMemoryUser()
        {
            UserModel = new List<UserModel>();
            SetUserCollection();
        }

        private void SetUserCollection()
        {
            UserModel.Add(new UserModel("mario", "secret", "mario.gmail.com"));
            UserModel.Add(new UserModel("jan", "secretsecret", "secret.gmail.com"));
            UserModel.Add(new UserModel("krzysiek", "secret2", "krzysiek.gmail.com"));
            UserModel.Add(new UserModel("wiesio", "secret3", "wiesio.gmail.com"));
            UserModel.Add(new UserModel("marian", "secret4", "marian.gmail.com"));
            UserModel.Add(new UserModel("andrzej", "secret5", "andrzej.gmail.com"));
            UserModel.Add(new UserModel("kaziu", "secret6", "kaziu.gmail.com"));

        }

        public IList<UserModel> GetAppUsers()
        {
            return UserModel;
        }



    }
}
