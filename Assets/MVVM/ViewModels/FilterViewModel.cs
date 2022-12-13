using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class FilterViewModel : ViewModelBase
    {
        public ICommand DeclineCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand AddSkillsCommand { get; set; }


        public event Action OnConfirm;

        private float _opacity;
        public float Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                _opacity = value;
                OnPropertyChanged();
            }
        }
                
        private IOrderRepository orderRepository;
        private IOrderSkillRepository orderSkillsRepository;


        public FilterViewModel()
        {
            orderRepository = new OrderRepository();
            orderSkillsRepository = new OrderSkillRepository();
        }
    }
}
