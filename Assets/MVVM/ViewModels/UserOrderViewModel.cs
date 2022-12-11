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
    class UserOrderViewModel : ViewModelBase
    {
        private UserModel _currentUser;



        IUserRepository userRepository;
        IOrderRepository orderRepository;
        private OrderModel _currentOrder;

        public event Action OnEditOrder;
        public event Action OnRemoveOrder;
        public event Action OnGoBack;
        public event Action<int> OnCheckProfile;
        public event Action<int,int> OnConfirmRespond;

        public List<ResponseModel> Responses { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand CheckProfileCommand { get; set; }
        public ICommand ConfirmResponseCommand { get; set; }

        public string AddressString
        {
            get
            {
                return CurrentOrder.Address == string.Empty ? string.Empty : "Адрес: " + CurrentOrder.Address;
            }
            set { }
        }

        public string LessonCountString
        {
            get
            {
                return CurrentOrder.LessonCount == 0 ? string.Empty : "Количество занятий: " + CurrentOrder.LessonCount;
            }
            set { }
        }

        public string BudgetString
        {
            get
            {
                return  "Бюджет: " + CurrentOrder.Budget+"руб";
            }
            set { }
        }

        public string GoalString
        {
            get
            {
                return "Цель: " + CurrentOrder.Goal;
            }
            set { }
        }

        public string NonrelDateString
        {
            get
            {
                return "Дата нерелевантности: " + CurrentOrder.NonrelDate.ToString("dd.MM.yyyy");
            }
            set { }
        }

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

        public UserOrderViewModel()
        {

        }


        public UserOrderViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();

            CurrentUser = user;
            CurrentOrder = new OrderModel();

            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
            RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand, CanExecuteRemoveCommand);
            GoBackCommand = new ViewModelCommand(ExecuteGoBackCommand);

            CheckProfileCommand=new ViewModelCommand(ExecuteCheckProfileCommand);
            ConfirmResponseCommand = new ViewModelCommand(ExecuteConfirmResponseCommand); 
        }

        private void ExecuteEditCommand(object obj)
        {
            OnEditOrder();
        } 
        
        private void ExecuteCheckProfileCommand(object obj)
        {
            OnCheckProfile((int)obj);
        }

        private void ExecuteConfirmResponseCommand(object obj)
        {
            orderRepository.ConfirmResponse(CurrentOrder, Responses.First(x => x.UserId == (int)obj));
            OnConfirmRespond((int)obj,CurrentOrder.Id);
        }

        private bool CanExecuteEditCommand(object obj)
        {
            return Responses.Count<=0;
        }
        private void ExecuteRemoveCommand(object obj)
        {
            orderRepository.Remove(CurrentOrder.Id);
            OnRemoveOrder();
        }

        private bool CanExecuteRemoveCommand(object obj)
        {
            return true;
        }
        private void ExecuteGoBackCommand(object obj)
        {
            OnGoBack();
        }

        public void UpdateOrder(int id)
        {
            CurrentOrder = orderRepository.GetById(id);
            Responses = orderRepository.GetResponsesById(id);
            Responses.ForEach(x => Console.WriteLine(x.IsAccepted + " " + x.IsAcceptedF));
        }

        public void UpdateInfo()
        {
            CurrentUser = userRepository.GetByUsername(CurrentUser.Username);
            Responses.ForEach(x => Console.WriteLine(x.IsAccepted + " " + x.IsAcceptedF));
        }
    }
}
