using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class AddEducationViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        string _institution;
        string _yearStart;
        string _yearEnd;

        string _errorMessage;

        IEducationRepository educationRepository;

        public ICommand DeclineCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }



        public event Action OnGoBack;
        public event Action OnConfirm;

        public string InstitutionString
        {
            get
            {
                return _institution;
            }
            set
            {
                _institution = value;
                OnPropertyChanged();
            }
        }

        public string YearStart
        {
            get
            {
                return _yearStart;
            }
            set
            {
                _yearStart = value;
                OnPropertyChanged();
            }
        }
        public string YearEnd
        {
            get
            {
                return _yearEnd;
            }
            set
            {
                _yearEnd = value;
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

        private int _idEduc;
        public int IdEducation
        {
            get
            {
                return _idEduc;
            }
            set
            {
                _idEduc = value;
                if (value == -1)
                {
                    InstitutionString = string.Empty;
                    YearStart = string.Empty;
                    YearEnd = string.Empty;
                }
                else
                {
                    var CurrentEducation = educationRepository.GetById(value);
                    InstitutionString = CurrentEducation.Institution;
                    YearStart = CurrentEducation.StartYear.ToString();
                    YearEnd = CurrentEducation.EndYear.ToString();
                }
            }
        }

        public AddEducationViewModel()
        {
        }

        public AddEducationViewModel(UserModel user)
        {
            educationRepository = new EducationRepository();

            CurrentUser = user;

            DeclineCommand = new ViewModelCommand(ExecuteDeclineCommand);
            ConfirmCommand = new ViewModelCommand(ExecuteConfirmCommand, CanExecuteConfirmCommand);
        }

        private void ExecuteDeclineCommand(object obj)
        {
            OnGoBack();
        }
        private void ExecuteConfirmCommand(object obj)
        {
            if (IdEducation != -1)
            {

                educationRepository.Edit(new EducationModel()
                {
                    Id=IdEducation,
                    Institution=InstitutionString,
                    EndYear = int.Parse(YearEnd),
                    StartYear = int.Parse(YearStart)
                });
            }
            else
            {
                Console.WriteLine(educationRepository.Add(new EducationModel()
                {
                    Institution = InstitutionString,
                    EndYear = int.Parse(YearEnd),
                    StartYear = int.Parse(YearStart)
                }, CurrentUser));
            }
            ModalWindow modal = new ModalWindow("Информация об образовании сохранена!");
            modal.ShowDialog();
            OnConfirm();
        }
        private bool CanExecuteConfirmCommand(object obj)
        {
            if (InstitutionString != string.Empty && InstitutionString.Length > 3 
                && int.TryParse(YearStart, out int ys) && ys > 1900 && ys < DateTime.Now.Year &&
                int.TryParse(YearEnd, out int ye) && ye > 1900 && ys < DateTime.Now.Year + 10 &&
                YearStart != string.Empty && YearEnd != string.Empty &&
                ys<=ye)
            {
                return true;
            }
            return false;
        }
    }
}
