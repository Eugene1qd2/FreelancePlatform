using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FreelancePlatform.Assets.Additional_Data;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credantial);
        ErrorStatus Add(UserModel userModel);
        void ChangePhoto(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetAll();
        byte[] ImageToByteArray(Image imageIn);
    }
}
