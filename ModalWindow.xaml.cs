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
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ModalWindow(string text)
        {
            Text = text;
            InitializeComponent();
        }

        private void CloseButtonClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
