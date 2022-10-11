using System;
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
using System.Windows.Shapes;

namespace FreelancePlatform
{
    /// <summary>
    /// Логика взаимодействия для AcceptionWindow.xaml
    /// </summary>
    public partial class AcceptionWindow : Window
    {
        public AcceptionWindow(string mail)
        {
            InitializeComponent();
            mailText.Text = "Код подтверждения пришёл вам на почту: " + mail;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        public string Code { get { return codeField.Text; } }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Hide();
        }
    }
}
