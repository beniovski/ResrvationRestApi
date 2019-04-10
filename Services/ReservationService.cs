using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationRestApi.Models;
using ReservationRestApi.Repository;
using ReservationRestApi.ViewModel;

namespace ReservationRestApi.Services
{ 
    public class ReservationService : IReservationService
    {
        private readonly IUserRepository _userRepository;

        private readonly IRoomsRepository _roomsRepository;

        private readonly IReservationDateRepository _reservationDateRepository;

        public ReservationService(IUserRepository userRepository, IRoomsRepository roomsRepository, IReservationDateRepository reservationDateRepository)
        {
            _reservationDateRepository = reservationDateRepository;

            _roomsRepository = roomsRepository;

            _userRepository = userRepository;
        }

        public async Task DeleteReservation(DeleteReservationModel DeleteReservationModel)
        {
            var user = await _userRepository.GetUserByNameAndLastName(DeleteReservationModel.Name, DeleteReservationModel.LastName);
            await _reservationDateRepository.DeleteReservationDate(DeleteReservationModel.StartReservarion, DeleteReservationModel.EndReservation, DeleteReservationModel.Number, user.Id);
            await _userRepository.DeleteUser(user.Id);
        }
      

        public async Task MakeReservation(ReservationModel reservationModel)
        {
            var user = new Users
            {
                Email = reservationModel.Email,
                Name = reservationModel.Name,
                LastName = reservationModel.LastName,
                Phone = reservationModel.Phone    
            };

            var userID = await _userRepository.AddUserReturnUserId(user);
            var room = await _roomsRepository.GetRoomByNumber((int)reservationModel.Number);
            await _reservationDateRepository.AddReservationDate((DateTime)reservationModel.StartReservarion, (DateTime)reservationModel.EndReservation, (int)reservationModel.Number, (int)userID);

        }

        public Task MakeReservation(DeleteReservationModel deleteReservationModel)
        {
            throw new NotImplementedException();
        }
    }
}
