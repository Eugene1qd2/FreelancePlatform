using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class UserModel
    {

        public int Id { get; set; }             //Unique
        public string Username { get; set; }    //Unique
        public SecureString Password { get; set; }    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }       //Unique
        public string Male { get; set; }
        public string Aboutme { get; set; }
        public Bitmap Photo { get; set; }   
        public DateTime Registrationdate { get; set; }
        public UserModel( string username, SecureString password, string name, string surname, string middlename, DateTime birthdate, string email, string male)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Middlename = middlename;
            Birthdate = birthdate;
            Email = email;
            Male = male;
        }

        
    }
}
