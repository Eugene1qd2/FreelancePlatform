﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credantial);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetAll();
    }
}