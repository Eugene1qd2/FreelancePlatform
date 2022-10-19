using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IUserSkillRepository
    {
        ErrorStatus Add(UserSkillModel workExp, UserModel user);
        void Remove(UserModel user,int id);
        List<UserSkillModel> GetByUserId(int userId);
    }
}
