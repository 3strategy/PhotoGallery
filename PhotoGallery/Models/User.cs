using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Input;

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

        public ICommand RegisterCommand => new Command(OnRegister);

        private void OnRegister()
        {
            ErrorMessage = "";
            if (UserName is null)
                ErrorMessage += "חייבים שם משתמש\n";
            else if (Regex.IsMatch(UserName, @"^\d") || UserName.Contains(" "))
                ErrorMessage += "שם המשתמש לא יכול להתחיל בספרה ואסור שיכיל רווחים\n";

            if(Password is null)
                ErrorMessage += "חייבים סיסמא\n";
            else if (!Regex.IsMatch(Password, @"^(?=.*[A-Z])(?=.*\d).+$"))
                ErrorMessage += "סיסמה חייבת להכיל לפחות אות גדולה אחת ומספר\n";

            if (Age < 18)
                ErrorMessage += "הגיל חייב להיות גדול מ-18\n";

            if (Email is null)
                ErrorMessage += "חייבים מייל\n";
            else if (!IsValidEmail(email))
                ErrorMessage += "מייל לא תקין\n";

            if(ErrorMessage =="")
                ErrorMessage = "Registration successful!";
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
