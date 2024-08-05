using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    internal class User:ObservableObject
    {
        private string name;
        private string userName;
        private string email;
        private string phone;
        private DateTime birthDate;
        private string password;
        private string errorMessage;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string UserName
        {
            get => userName;
            set { userName = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(); }
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set { birthDate = value; OnPropertyChanged(); OnPropertyChanged(nameof(Age)); }
        }

        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set { errorMessage = value; OnPropertyChanged(); }
        }

        public int Age => (DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0));

    }
}
