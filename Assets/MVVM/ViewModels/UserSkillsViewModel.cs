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
    class UserSkillsViewModel : ViewModelBase
    {
        private UserModel _currentUser;
        private List<UserSkillModel> _userSkills;
        private List<UserSkillModel> _displauSkills;
        private List<UserSkillModel> _allSkills;

        private string _searchSkills;

        string _errorMessage;

        IUserRepository userRepository;
        IUserSkillRepository userSkillRepository;

        public ICommand DeclineChangeSkillsCommand { get; set; }
        public ICommand RemoveSkillCommand { get; set; }
        public ICommand AddSkillCommand { get; set; }



        public event Action OnGoBack;

        public string SearchSkills
        {
            get { return _searchSkills; }
            set
            {
                _searchSkills = value;
                OnPropertyChanged();
                FilterSkills();
            }
        }


        public List<UserSkillModel> Skills
        {
            get
            {
                return _displauSkills;
            }
            set
            {
                _displauSkills = value;
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

        private void FilterSkills()
        {
            Skills = _allSkills.Except(UserSkills, new ListComparer()).ToList();

            if (Skills!=null && SearchSkills!=string.Empty)
            {
            Skills = Skills.Where(x =>  x.Skill.Contains(SearchSkills)).ToList();
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


        public UserSkillsViewModel()
        {
        }

        public UserSkillsViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            userSkillRepository = new UserSkillRepository();

            CurrentUser = user;
            UserSkills = userSkillRepository.GetByUserId(CurrentUser.Id);
            _allSkills = userSkillRepository.GetAllSkills();
            Skills = _allSkills.Except(UserSkills, new ListComparer()).ToList();

            DeclineChangeSkillsCommand = new ViewModelCommand(ExecuteDeclineChangeSkillsCommand);
            AddSkillCommand = new ViewModelCommand(ExecuteAddSkillsCommand);
            RemoveSkillCommand = new ViewModelCommand(ExecuteRemoveSkillCommand);
        }

        private void ExecuteDeclineChangeSkillsCommand(object obj)
        {
            OnGoBack();
        }

        private void ExecuteRemoveSkillCommand(object obj)
        {
            UserSkillModel skill = userSkillRepository.GetById((int)obj);

            skill.UserId = CurrentUser.Id;
            userSkillRepository.Remove(CurrentUser, skill.Id);

            UpdateSkills();
            FilterSkills();
        }

        private void ExecuteAddSkillsCommand(object obj)
        {
            UserSkillModel skill = userSkillRepository.GetById((int)obj);

            skill.UserId = CurrentUser.Id;
            userSkillRepository.Add(skill, CurrentUser);

            UpdateSkills();
            FilterSkills();
        }

        private void UpdateSkills()
        {
            UserSkills = userSkillRepository.GetByUserId(CurrentUser.Id);
            Skills = _allSkills.Except(UserSkills,new ListComparer()).ToList();
        }
    }
    public class ListComparer : IEqualityComparer<UserSkillModel>
    {
        bool IEqualityComparer<UserSkillModel>.Equals(UserSkillModel x, UserSkillModel y)
        {
            return (x.Skill.Equals(y.Skill) && x.Id.Equals(y.Id));
        }

        int IEqualityComparer<UserSkillModel>.GetHashCode(UserSkillModel obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;

            return obj.Skill.GetHashCode() + obj.Id;
        }
    }
}
