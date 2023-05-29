using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IReviewRepository
    {
        ErrorStatus Add(ReviewModel review);
        void Edit(ReviewModel review);
        void Remove(int id);
        ObservableCollection<ReviewModel> GetByUserId(int userId);
        ReviewModel GetById(int Id);
    }
}
