using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FreelancePlatform
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public EnterWindow enterWindow;
        public RegistrationWindow registrationWindow;
        public MainWindow mainWindow;

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            enterWindow = new EnterWindow();
            registrationWindow = new RegistrationWindow();
            enterWindow.Show();

            enterWindow.IsVisibleChanged += (s, ev) =>
            {
                if (enterWindow.Tag.ToString()=="True")
                {
                    if (enterWindow.IsVisible == false)
                    {
                        mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                }
                else
                {
                    if (enterWindow.IsVisible == false)
                    {
                        registrationWindow.Show();
                    }
                }
            };
        }
    }
}
