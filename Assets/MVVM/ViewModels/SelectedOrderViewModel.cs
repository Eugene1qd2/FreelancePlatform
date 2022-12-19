using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class SelectedOrderViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        IUserRepository userRepository;
        IOrderRepository orderRepository;
        private OrderModel _currentOrder;

        public event Action<int> OnRespondOrder;
        public event Action OnGoBack;
        public event Action<int> OnCheckProfile;

        public List<ResponseModel> Responses { get; set; }

        public ICommand GoBackCommand { get; set; }
        public ICommand CheckProfileCommand { get; set; }
        public ICommand RespondCommand { get; set; }

        private bool isResponded;


        public UserModel CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }
        public OrderModel CurrentOrder
        {
            get
            {
                return _currentOrder;
            }
            set
            {
                _currentOrder = value;
                OnPropertyChanged();
            }
        }

        public SelectedOrderViewModel()
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();

            CurrentOrder = new OrderModel();

            GoBackCommand = new ViewModelCommand(ExecuteGoBackCommand);

            CheckProfileCommand = new ViewModelCommand(ExecuteCheckProfileCommand);
            RespondCommand = new ViewModelCommand(ExecuteRespondCommand);
        }

        public SelectedOrderViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();

            CurrentUser = user;
            CurrentOrder = new OrderModel();

            GoBackCommand = new ViewModelCommand(ExecuteGoBackCommand);

            CheckProfileCommand = new ViewModelCommand(ExecuteCheckProfileCommand);
            RespondCommand = new ViewModelCommand(ExecuteRespondCommand, CanExecuteRespondCommand);
        }

        private void ExecuteCheckProfileCommand(object obj)
        {
            OnCheckProfile(CurrentOrder.UserId);
        }
        private bool CanExecuteRespondCommand(object obj)
        {
            return !isResponded;
        }

        private void ExecuteRespondCommand(object obj)
        {
            orderRepository.AddResponse(CurrentOrder, CurrentUser);
            ModalWindow modal = new ModalWindow("Ваш отклик сохранён!\nЧат создан!");
            modal.ShowDialog();
            OnRespondOrder(CurrentOrder.Id);
            isResponded = true;
        }

        private void ExecuteGoBackCommand(object obj)
        {
            OnGoBack();
        }

        public void UpdateOrder(int id)
        {
            CurrentOrder = orderRepository.GetById(id);
            Responses = orderRepository.GetResponsesById(id);
            isResponded = (Responses.Count(x => x.UserId == CurrentUser.Id) == 1) || (CurrentOrder.UserId == CurrentUser.Id);
        }

        public void UpdateInfo()
        {
            CurrentUser = userRepository.GetByUsername(CurrentUser.Username);
        }
    }
}
