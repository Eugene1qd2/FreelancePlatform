using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class UserAccauntViewModel : ViewModelBase
    {
        private UserModel _currentUser;
        private List<EducationModel> _educations;
        private List<WorkExpModel> _workExps;
        private List<UserSkillModel> _userSkills;
        private List<CertificateModel> _certificates;

        BitmapImage _photoName;
        byte[] defaultImage;
        string _errorMessage;

        IUserRepository userRepository;
        IEducationRepository educationRepository;
        IWorkExpRepository workExpRepository;
        IUserSkillRepository userSkillRepository;
        ICertificateRepository certificateRepository;

        //public delegate void StartChangingSkills();
        public event Action OnChangeSkills;

        public ICommand ChangeUserPhotoCommand { get; set; }
        public ICommand ConfirmAboutMeCommand { get; set; }
        public ICommand ChangeSkillsCommand { get; set; }

        public List<EducationModel> Educations
        {
            get
            {
                return _educations;
            }
            set
            {
                _educations = value;
                OnPropertyChanged();
            }
        }

        public List<WorkExpModel> WorkExps
        {
            get
            {
                return _workExps;
            }
            set
            {
                _workExps = value;
                OnPropertyChanged();
            }
        }

        public List<UserSkillModel> UserSkills
        {
            get
            {
                return _userSkills;
            }
            set
            {
                _userSkills = value;
                OnPropertyChanged();
            }
        }

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
        public List<CertificateModel> Certificates
        {
            get
            {
                return _certificates;
            }
            set
            {
                _certificates = value;
                OnPropertyChanged();
            }
        }

        public UserAccauntViewModel()
        {
            ErrorMessage = "Вы не вошли в учётную запись пользователя!";
        }


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
            educationRepository = new EducationRepository();
            workExpRepository = new WorkExpRepository();
            userSkillRepository = new UserSkillRepository();
            certificateRepository = new CertificateRepository();

            CurrentUser = user;
            Educations = educationRepository.GetByUserId(CurrentUser.Id);
            WorkExps = workExpRepository.GetByUserId(CurrentUser.Id);
            UserSkills = userSkillRepository.GetByUserId(CurrentUser.Id);
            Certificates = certificateRepository.GetByUserId(CurrentUser.Id);

            if (Educations.Count == 0)
            {
                Educations = new List<EducationModel>();
                Educations.Add(new EducationModel() { Institution = "Отсутствует" });
            }
            if (WorkExps.Count == 0)
            {
                WorkExps = new List<WorkExpModel>();
                WorkExps.Add(new WorkExpModel() { Company = "Отсутствует" });
            }
            if (UserSkills.Count == 0)
            {
                UserSkills = new List<UserSkillModel>();
                UserSkills.Add(new UserSkillModel() { Skill = "Отсутствует" });
            }
            if (Certificates.Count == 0)
            {
                Certificates = new List<CertificateModel>();
                Certificates.Add(new CertificateModel() { Organization = "Отсутствует" });
            }

            using (FileStream fs = new FileStream("..\\..\\Assets\\Images\\Default.png", FileMode.Open))
            {
                defaultImage = new byte[fs.Length];
                fs.Read(defaultImage, 0, defaultImage.Length);
            }

            UpdatePhoto();

            ChangeUserPhotoCommand = new ViewModelCommand(ExecuteChangeUserPhotoCommand);
            ConfirmAboutMeCommand = new ViewModelCommand(ExecuteConfirmAboutMeCommand);
            ChangeSkillsCommand = new ViewModelCommand(ExecuteChangeSkillsCommand);
        }

        private void ExecuteChangeSkillsCommand(object obj)
        {
            OnChangeSkills();
        }

        private void ExecuteConfirmAboutMeCommand(object obj)
        {
            userRepository.ChangeAboutMeByUsername(CurrentUser);
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

        public void UpdateInfo()
        {
            Educations = educationRepository.GetByUserId(CurrentUser.Id);
            WorkExps = workExpRepository.GetByUserId(CurrentUser.Id);
            UserSkills = userSkillRepository.GetByUserId(CurrentUser.Id);
            Certificates = certificateRepository.GetByUserId(CurrentUser.Id);

            if (Educations.Count == 0)
            {
                Educations = new List<EducationModel>();
                Educations.Add(new EducationModel() { Institution = "Отсутствует" });
            }
            if (WorkExps.Count == 0)
            {
                WorkExps = new List<WorkExpModel>();
                WorkExps.Add(new WorkExpModel() { Company = "Отсутствует" });
            }
            if (UserSkills.Count == 0)
            {
                UserSkills = new List<UserSkillModel>();
                UserSkills.Add(new UserSkillModel() { Skill = "Отсутствует" });
            }
            if (Certificates.Count == 0)
            {
                Certificates = new List<CertificateModel>();
                Certificates.Add(new CertificateModel() { Organization = "Отсутствует" });
            }

            using (FileStream fs = new FileStream("..\\..\\Assets\\Images\\Default.png", FileMode.Open))
            {
                defaultImage = new byte[fs.Length];
                fs.Read(defaultImage, 0, defaultImage.Length);
            }

            UpdatePhoto();
        }
    }
}
