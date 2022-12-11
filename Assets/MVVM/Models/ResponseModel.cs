using FreelancePlatform.Assets.MVVM.ViewModels;
using FreelancePlatform.Assets.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class ResponseModel
    {
        public int UserId { get; set; }
        public int AdId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsAcceptedF { get { return !IsAccepted; } set { } }

        public UserModel User { get; set; }
        public OrderModel Order { get; set; }

        private IUserRepository userRepository;

        private IOrderRepository orderRepository;

        public ResponseModel()
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();
        }

        public ResponseModel(int userId, int adId, bool isAccepted)
        {
            UserId = userId;
            AdId = adId;
            IsAccepted = isAccepted;
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();
            User = userRepository.GetById(userId);
            Order = orderRepository.GetById(adId);
        }

        public void UpdateResponse()
        {
            User = userRepository.GetById(UserId);
            Order = orderRepository.GetById(AdId);
        }
    }
}
