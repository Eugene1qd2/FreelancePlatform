using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IUserStatsRepository
    {
        float GetRateById(int Id);
        int GetAcceptedOrdersCountById(int Id);
        int GetLeftOrdersCountById(int Id);
    }
}
