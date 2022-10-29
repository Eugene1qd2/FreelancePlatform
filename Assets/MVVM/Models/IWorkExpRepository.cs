using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IWorkExpRepository
    {
        ErrorStatus Add(WorkExpModel workExp, UserModel user);
        void Edit(WorkExpModel workExp);
        void Remove(int id);
        List<WorkExpModel> GetByUserId(int userId);
        WorkExpModel GetById(int Id);
    }
}
