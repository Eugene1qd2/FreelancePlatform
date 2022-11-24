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
    class SomeOnesAccauntViewModel : ViewModelBase
    {
        private UserModel _currentUser;
        private List<EducationModel> _educations;
        private List<WorkExpModel> _workExps;
        private List<UserSkillModel> _userSkills;
        private List<CertificateModel> _certificates;

        string _errorMessage;


        IUserRepository userRepository;
        IEducationRepository educationRepository;
        IWorkExpRepository workExpRepository;
        IUserSkillRepository userSkillRepository;
        ICertificateRepository certificateRepository;

        public event Action OnGoBack;

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

        public string AboutUser
        {
            get
            {
                return _currentUser.Aboutme;
            }
            set
            {
                _currentUser.Aboutme = value;
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
        public SomeOnesAccauntViewModel()
        {
            userRepository = new UserRepository();
            educationRepository = new EducationRepository();
            workExpRepository = new WorkExpRepository();
            userSkillRepository = new UserSkillRepository();
            certificateRepository = new CertificateRepository();
        }


        public void UpdateInfo(int id)
        {
            CurrentUser = userRepository.GetById(id);
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
        }
    }
}
