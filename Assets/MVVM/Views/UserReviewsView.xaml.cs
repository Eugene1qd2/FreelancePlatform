﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FreelancePlatform.Assets.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для UserAccountView.xaml
    /// </summary>
    public partial class UserReviewsView : UserControl
    {
        public UserReviewsView()
        {
            InitializeComponent();
        }

        private void GetRate_ValueChanged(int obj)
        {
            RateVal.Text = Convert.ToString(GetRate.RateValue);
        }
    }
}
