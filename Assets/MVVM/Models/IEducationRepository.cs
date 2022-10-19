using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IEducationRepository
    {
        ErrorStatus Add(EducationModel education, UserModel user);
        void Edit(EducationModel education);
        void Remove(int id);
        List<EducationModel> GetByUserId(int userId);
    }
}
