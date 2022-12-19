using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FreelancePlatform.Assets.Additional_Data;
using System.Windows.Controls;
using System.Windows;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private UserAccauntViewModel userAccaunt { get; set; }
        private ApplicationSettingsViewModel applicationSettings { get; set; }
        private MyOrdersViewModel myOrders { get; set; }
        private UserSkillsViewModel userSkills { get; set; }
        private EducationViewModel educations { get; set; }
        private WorkExpViewModel workExps { get; set; }
        private CertificateViewModel certificates { get; set; }
        private AddWorkExpViewModel addWorkExps { get; set; }
        private AddEducationViewModel addEducations { get; set; }
        private AddCertificateViewModel addCertificates { get; set; }
        private AddOrderViewModel addOrders { get; set; }
        private OrderSkillsViewModel addOrderSkills { get; set; }
        private UserOrderViewModel userOrder { get; set; }
        private SomeOnesAccauntViewModel someOnesAccaunt { get; set; }
        private OrdersViewModel orders { get; set; }
        private SelectedOrderViewModel selectedOrder { get; set; }
        private UserChatViewModel userChat { get; set; }
        private ChatsViewModel chats { get; set; }
        private FilterViewModel filter { get; set; }

        private string _username;
        private string _errorMessage;
        private object _currentView;
        private object _filterView;
        private UserModel _currentUser;

        private int _width;
        public int Width { get => _width; set { _width = value; OnPropertyChanged(); } }

        private float _chatOpacity;
        public float ChatOpacity
        {
            get
            {
                return _chatOpacity;
            }
            set
            {
                _chatOpacity = value;
                OnPropertyChanged();
            }
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

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public object FilterView
        {
            get
            {
                return _filterView;
            }
            set
            {
                _filterView = value;
                OnPropertyChanged();
            }
        }

        private IUserRepository userRepository;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value; OnPropertyChanged();
            }

        }
        public ICommand UserAccauntCommand { get; }
        public ICommand OrdersListCommand { get; }
        public ICommand ChatsCommand { get; }
        public ICommand MyOrdersCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand CloseApplicationCommand { get; }

        public MainViewModel()
        {

            filter = new FilterViewModel();
            FilterView = null;
            userRepository = new UserRepository();

            CurrentUser = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            Width = 1220;
            // Main vms:
            userAccaunt = new UserAccauntViewModel(CurrentUser);
            applicationSettings = new ApplicationSettingsViewModel();
            myOrders = new MyOrdersViewModel(CurrentUser);
            addOrders = new AddOrderViewModel(CurrentUser);
            orders = new OrdersViewModel(CurrentUser);
            chats=new ChatsViewModel(CurrentUser);

            // UA additional vms:
            userSkills = new UserSkillsViewModel(CurrentUser);
            educations = new EducationViewModel(CurrentUser);
            workExps = new WorkExpViewModel(CurrentUser);
            certificates = new CertificateViewModel(CurrentUser);
            addEducations = new AddEducationViewModel(CurrentUser);
            addWorkExps = new AddWorkExpViewModel(CurrentUser);
            addCertificates = new AddCertificateViewModel(CurrentUser);
            addOrderSkills = new OrderSkillsViewModel();
            userOrder = new UserOrderViewModel(CurrentUser);
            someOnesAccaunt = new SomeOnesAccauntViewModel();
            selectedOrder = new SelectedOrderViewModel(CurrentUser);
            userChat = new UserChatViewModel(CurrentUser);
            CurrentView = userAccaunt;
            UserAccauntCommand = new ViewModelCommand(o =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
                FilterView = null;
                Width = 1220;
            });
            OrdersListCommand = new ViewModelCommand(o =>
            {
                CurrentView = orders;
                orders.UpdateInfo();
                FilterView = filter;
                Width = 1220;
            });
            ChatsCommand = new ViewModelCommand(o =>
            {
                CurrentView = chats;
                chats.UpdateInfo();
                FilterView = null;
                Width = 1220;
                ChatOpacity = 0;
            });
            MyOrdersCommand = new ViewModelCommand(o =>
            {
                CurrentView = myOrders;
                FilterView = null;
                Width = 1220;
            });
            SettingsCommand = new ViewModelCommand(o =>
            {
                CurrentView = applicationSettings;
                FilterView = null;
                Width = 1220;
            });



            CloseApplicationCommand = new ViewModelCommand(o =>
            {
                userChat.Disconnect();
                Application.Current.Shutdown();
            });

            /// <summary>
            /// Filter triggers
            /// </summary>
            filter.OnApplyFilter += (FilterStruct filter) =>
            {
                orders.UpdateInfo(filter);
            };

            /// <summary>
            /// OrdersList triggers
            /// </summary>
            orders.OnSelectOrder += (int id) =>
            {
                CurrentView = selectedOrder;
                selectedOrder.UpdateOrder(id);
                FilterView = null;
                Width = 1220;
            };
            selectedOrder.OnRespondOrder += (int id) =>
            {
                userChat.CreateChatById(id);
                Width = 1220;
            };
            selectedOrder.OnGoBack += () =>
            {
                orders.UpdateInfo();
                CurrentView = orders;
                FilterView = filter;
                Width = 1220;
            };
            selectedOrder.OnCheckProfile += (int id) =>
            {
                someOnesAccaunt.UpdateInfo(id);
                CurrentView = someOnesAccaunt;
                Width = 1220;
            };

            /// <summary>
            /// SomeOnesUser Accaunt triggers
            /// </summary>
            someOnesAccaunt.OnWriteMessage += (int id) =>
            {
                userChat.CreateChatByTopic("Диалог", id);
                Width = 1220;
            };

            /// <summary>
            /// User Chat triggers
            /// </summary>
            chats.OnSelectChat += (int id) =>
            {

                userChat.UpdateInfo(id,true);
                CurrentView = userChat;
                Width = 1220;

            };
            userChat.OnGoBack += () =>
            {
                chats.UpdateInfo();
                CurrentView = chats;
                Width = 1220;
            };

            userChat.OnCheckProfile += (int id) =>
            {
                someOnesAccaunt.UpdateInfo(id);
                CurrentView = someOnesAccaunt;
                Width = 1220;
            };
            userChat.OnNewMessage += (int chatId) =>
            {
                if (CurrentView!=chats)
                {
                    ChatOpacity = 1;
                }
                else
                {
                    ChatOpacity = 0;
                }
            };
            /// <summary>
            /// User Accaunt triggers
            /// </summary>
            userAccaunt.OnChangeSkills += () =>
            {
                CurrentView = userSkills;
                Width = 1220;
            };

            userAccaunt.OnChangeEducations += () =>
            {
                CurrentView = educations;
                educations.UpdateInfo();
                Width = 1220;
            };

            userAccaunt.OnChangeWorkExps += () =>
            {
                CurrentView = workExps;
                Width = 1220;
            };

            userAccaunt.OnChangeCertificates += () =>
            {
                CurrentView = certificates;
                Width = 1220;
            };

            /// <summary>
            /// User Orders triggers
            /// </summary>
            myOrders.OnAddOrder += () =>
            {
                CurrentView = addOrders;
                addOrders.IdOrder = -1;
                Width = 1600;
            };
            myOrders.OnSelectOrder += (int Id) =>
            {
                CurrentView = userOrder;
                userOrder.UpdateOrder(Id);
                Width = 1220;
            };
            userOrder.OnGoBack += () =>
            {
                CurrentView = myOrders;
                myOrders.UpdateInfo();
                Width = 1220;
            };
            userOrder.OnEditOrder += () =>
            {
                addOrders.IdOrder = userOrder.CurrentOrder.Id;
                CurrentView = addOrders;
                Width = 1600;
            };
            userOrder.OnRemoveOrder += () =>
            {
                CurrentView = myOrders;
                myOrders.UpdateInfo();
                Width = 1220;
            };
            userOrder.OnConfirmRespond += (int Userid,int OrderId) =>
            {
                int chatId=userChat.SendConfirmMessage(Userid, OrderId);
                userChat.UpdateInfo(chatId,false);
                CurrentView = userChat;
            };
            addOrders.OnGoBack += () =>
            {
                CurrentView = myOrders;
                myOrders.UpdateInfo();
                addOrders.OrderSkills = new List<OrderSkillModel>();
                if (addOrders.SelectedOrder != null)
                {
                    addOrders.SelectedOrder.OrderSkills = new List<OrderSkillModel>();
                }
                Width = 1220;
            };
            addOrders.OnConfirm += () =>
            {
                CurrentView = myOrders;
                Width = 1220;
                myOrders.UpdateInfo();
            };
            addOrders.OnAddSkills += () =>
            {
                Width = 1220;
                addOrderSkills.UpdateInfo(addOrders.SelectedOrder);
                addOrders.OrderSkills = addOrderSkills.OrderSkills;
                if (addOrders.SelectedOrder != null)
                {
                    addOrders.SelectedOrder.OrderSkills = addOrderSkills.OrderSkills;
                }
                addOrderSkills.UpdateInfo(addOrders.SelectedOrder);
                CurrentView = addOrderSkills;
            };
            addOrderSkills.OnGoBack += () =>
            {
                Width = 1600;
                CurrentView = addOrders;
                addOrders.OrderSkills = addOrderSkills.OrderSkills;
                if (addOrders.SelectedOrder != null)
                {
                    addOrders.SelectedOrder.OrderSkills = addOrderSkills.OrderSkills;
                }
            };
            userOrder.OnCheckProfile += (int id) =>
            {
                someOnesAccaunt.UpdateInfo(id);
                Width = 1220;
                CurrentView = someOnesAccaunt;
            };
            /// <summary>
            /// Education triggers
            /// </summary>
            educations.OnAddEducation += () =>
            {
                addEducations.IdEducation = -1;
                CurrentView = addEducations;
                Width = 1220;
            };
            educations.OnEditEducation += (int Id) =>
            {
                addEducations.IdEducation = Id;
                CurrentView = addEducations;
                Width = 1220;
            };

            educations.OnGoBack += () =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
                Width = 1220;
            };

            addEducations.OnGoBack += () =>
            {
                CurrentView = educations;
                educations.UpdateInfo();
                Width = 1220;
            };

            addEducations.OnConfirm += () =>
            {
                CurrentView = educations;
                educations.UpdateInfo();
                Width = 1220;
            };

            /// <summary>
            /// WorkExp triggers
            /// </summary>
            workExps.OnAddWorkExp += () =>
            {
                addWorkExps.IdWorkExp = -1;
                CurrentView = addWorkExps;
                Width = 1220;

            };
            workExps.OnEditWorkExp += (int Id) =>
            {
                addWorkExps.IdWorkExp = Id;
                CurrentView = addWorkExps;
                Width = 1220;
            };

            workExps.OnGoBack += () =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
                Width = 1220;
            };

            addWorkExps.OnGoBack += () =>
            {
                CurrentView = workExps;
                workExps.UpdateInfo();
                Width = 1220;
            };

            addWorkExps.OnConfirm += () =>
            {
                CurrentView = workExps;
                workExps.UpdateInfo();
                Width = 1220;
            };

            /// <summary>
            /// Certificate triggers
            /// </summary>
            certificates.OnAddCertificate += () =>
            {
                addCertificates.IdCertificate = -1;
                CurrentView = addCertificates;
                Width = 1220;

            };
            certificates.OnEditCertificate += (int Id) =>
            {
                addCertificates.IdCertificate = Id;
                CurrentView = addCertificates;
                Width = 1220;
            };

            certificates.OnGoBack += () =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
                Width = 1220;
            };

            addCertificates.OnGoBack += () =>
            {
                CurrentView = certificates;
                certificates.UpdateInfo();
                Width = 1220;
            };

            addCertificates.OnConfirm += () =>
            {
                CurrentView = certificates;
                certificates.UpdateInfo();
                Width = 1220;
            };

            /// <summary>
            /// User Skills triggers
            /// </summary>
            userSkills.OnGoBack += () =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
                Width = 1220;
            };
        }
    }
}
