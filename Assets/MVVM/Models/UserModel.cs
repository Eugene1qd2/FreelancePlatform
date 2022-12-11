using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class UserModel
    {
        public string FIO { get; set; }
        public int Id { get; set; }             //Unique
        public string Username { get; set; }               //Unique
        public string Password { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpdateFIO();
            }

        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                UpdateFIO();
            }
        }
        private string _middlename;
        public string Middlename
        {
            get { return _middlename; }
            set
            {
                _middlename = value;
                UpdateFIO();
            }
        }
        private DateTime _birthdate;
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
                UpdateBDStr();
            }
        }
        public string BirthdateString { get; set; }
        public string Email { get; set; }     
        public string Male { get; set; }
        public string Aboutme { get; set; }
        private byte[] _photo;
        public byte[] Photo { get { return _photo; } set { _photo = value; UpdatePhoto(); } }

        BitmapImage _photoName;
        private void UpdatePhoto()
        {
            if (Photo != null)
                using (var ms = new MemoryStream(Photo))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    PhotoImg = image;
                }
        }
        public BitmapImage PhotoImg
        {
            get
            {
                return _photoName;
            }
            set
            {
                _photoName = value;
            }
        }
        public DateTime Registrationdate { get; set; }
        public UserModel(string username, string password, string name, string surname, string middlename, DateTime birthdate, string email, string male)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Middlename = middlename;
            Birthdate = birthdate;
            Email = email;
            Male = male;
            FIO = Surname + " " + Name + " " + Middlename;
        }
        private void UpdateFIO()
        {
            FIO = Surname + " " + Name + " " + Middlename;
        }
        private void UpdateBDStr()
        {
            BirthdateString = Birthdate.ToString("dd.MM.yyyy");
        }
        public UserModel()
        {
        }
    }
}
