using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IOrderSkillRepository
    {
        ErrorStatus Add(OrderSkillModel workExp, OrderModel user);
        ErrorStatus Add(List<OrderSkillModel> workExp, OrderModel user);
        void Remove(OrderModel order,int id);
        List<OrderSkillModel> GetByOrderId(int orderId);
        List<OrderSkillModel> GetExceptOrderId(int orderId);
        OrderSkillModel GetById(int Id);
        List<OrderSkillModel> GetAllSkills();
    }
}
