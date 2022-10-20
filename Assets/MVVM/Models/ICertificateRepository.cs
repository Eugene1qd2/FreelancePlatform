using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface ICertificateRepository
    {
        ErrorStatus Add(CertificateModel certificate, UserModel user);
        void Edit(CertificateModel certificate);
        void Remove(int id);
        List<CertificateModel> GetByUserId(int userId);
    }
}
