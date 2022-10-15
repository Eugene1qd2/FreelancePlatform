using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class UserAccauntViewModel : ViewModelBase
    {
        private UserModel _currentUser;
        private Image _pngPhoto;

        IUserRepository userRepository;
        public Image PngPhoto
        {
            get
            {
                return _pngPhoto;
            }
            set
            {
                _pngPhoto = value;
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

        public UserAccauntViewModel() { }

        public UserAccauntViewModel(UserModel user)
        {
            userRepository = new UserRepository(); //сделать изображение по гайду. Проблема была в том, что я плохо его прочитал. Удосужся дочитать пожалуйста.
            _currentUser = user;
            PngPhoto = userRepository.GetImage(user.Photo);
        }
    }
}
