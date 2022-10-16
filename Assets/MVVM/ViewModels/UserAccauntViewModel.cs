using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class UserAccauntViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        BitmapImage _photoName;

        string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        IUserRepository userRepository;
        public BitmapImage PhotoName
        {
            get
            {
                return _photoName;
            }
            set
            {
                _photoName = value;
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
        public ICommand ChangeUserPhotoCommand { get; set; }

        public UserAccauntViewModel()
        {
            ErrorMessage = "Вы не вошли в учётную запись пользователя!";
        }

        byte[] defaultImage;

        private void UpdatePhoto()
        {
            using (var ms = new MemoryStream(CurrentUser.Photo ?? defaultImage))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                PhotoName = image;
            }
        }

        public UserAccauntViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            CurrentUser = user;
            using (System.IO.FileStream fs = new System.IO.FileStream("..\\..\\Assets\\Images\\Default.png", FileMode.Open))
            {
                defaultImage = new byte[fs.Length];
                fs.Read(defaultImage, 0, defaultImage.Length);
            }

            UpdatePhoto();

            ChangeUserPhotoCommand = new ViewModelCommand(ExecuteChangeUserPhotoCommand);
        }

        private void ExecuteChangeUserPhotoCommand(object obj)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG |*.png";
            if (dialog.ShowDialog() == true)
            {
                Image img = Image.FromFile(dialog.FileName);
                CurrentUser.Photo = userRepository.ImageToByteArray(img);
                UpdatePhoto();
                userRepository.ChangePhoto(CurrentUser);
            }
        }
    }
}
