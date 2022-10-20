using FreelancePlatform.Assets.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class CertificateModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Organization { get; set; }
        public string Skill { get; set; }
        public string Link { get; set; }

        private string _certificateString;
        private bool _isValid;
        public string CertificateString
        {
            get
            {
                _certificateString = UserId == 0 ? Organization : ("Организация: "+ Organization + "\nНавык: " + Skill);
                return _certificateString;
            }
        }
        public ICommand FollowLinkCommand { get; set; }

        public CertificateModel()
        {
            _isValid = true;
            FollowLinkCommand = new ViewModelCommand(ExecuteFollowLinkCommand, CanExecuteFollowLinkCommand);
        }

        private bool CanExecuteFollowLinkCommand(object obj)
        {
            return !((string)obj == string.Empty) && _isValid;
        }

        private void ExecuteFollowLinkCommand(object obj)
        {
            try
            {
            Process.Start(new ProcessStartInfo(Link) { UseShellExecute = true });
            }
            catch
            {
                _isValid = false;
            }
        }
    }
}
