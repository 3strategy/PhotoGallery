using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace PhotoGallery.ViewModels
{
    internal class RegistrationPageViewModel:ViewModelBase
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
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(RegisterEnabled));
                }
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(RegisterEnabled));
                    OnPropertyChanged(nameof(CancelEnabled));

                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime BirthDate
        {
            get => birthDate;

            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Age));
                }
            }

        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(RegisterEnabled));
                    OnPropertyChanged(nameof(CancelEnabled));
                }
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool RegisterEnabled
        {
            get => Name is not null &&
                Password is not null &&
                UserName is not null &&
                Name != "" && Password != "" && UserName != "";
        }

        public bool CancelEnabled
        {
            get => UserName is not null && UserName != "" ||
                Password is not null && Password != "";
        }

        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

        public ICommand RegisterCommand => new Command(OnRegister);
        public ICommand CancelCommand => new Command(OnCancel);

        private void OnRegister()
        {
            ErrorMessage = "";
            if (UserName is null)
                ErrorMessage += "חייבים שם משתמש\n";
            else if (Regex.IsMatch(UserName, @"^\d") || UserName.Contains(" "))
                ErrorMessage += "שם המשתמש לא יכול להתחיל בספרה ואסור שיכיל רווחים\n";

            if (Password is null)
                ErrorMessage += "חייבים סיסמא\n";
            else if (!Regex.IsMatch(Password, @"^(?=.*[A-Z])(?=.*\d).+$"))
                ErrorMessage += "סיסמה חייבת להכיל לפחות אות גדולה אחת ומספר\n";

            if (Age < 18)
                ErrorMessage += "הגיל חייב להיות גדול מ-18\n";

            if (Email is null)
                ErrorMessage += "חייבים מייל\n";
            else if (!IsValidEmail(email))
                ErrorMessage += "מייל לא תקין\n";

            if (UserName != Password)
                ErrorMessage += "UserName Must match Password שם משתמש/סיסמה לא תקינים";
            if (ErrorMessage == "")
                ErrorMessage = "Registration successful!";
        }
        private void OnCancel()
        {
            Name = "";
            UserName = "";
            Password = "";
            Phone = "";

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