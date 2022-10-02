using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passwrod { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Male { get; set; }
        public string Aboutme { get; set; }
        public Bitmap Photo { get; set; }   
        public DateTime Registrationdate { get; set; }
    }
}
