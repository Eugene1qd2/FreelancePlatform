using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IOrderRepository
    {
        ErrorStatus Add(OrderModel order, UserModel user);
        void Edit(OrderModel order);
        void Remove(int id);
        List<OrderModel> GetByUserId(int userId);
        OrderModel GetById(int Id);
        List<ResponseModel> GetResponsesById(int orderId);
    }
}
