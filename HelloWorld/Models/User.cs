using System.ComponentModel;
using System.Text.RegularExpressions;

namespace HelloWorld.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;
        private string nameError;
        private string passError;
        private bool isvalidated;


        public override string ToString()
        {
            return name;
        }
        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }


        public string PassError
        {
            get
            {
                return passError;
            }
            set
            {
                if (passError != value)
                {
                    passError = value;
                    OnPropertyChanged("PassError");
                }
            }
        }




        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return NameError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {
                NameError = "";
                PassError = "";
                switch (columnName)
                {
                    case "Name":
                        {
                            if (string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }
                            break;
                        }
                    case "Password":
                        {
                            if (isvalidated == false)
                            {
                                var hasNumber = new Regex(@"[0-9]+");
                                var hasUpperChar = new Regex(@"[A-Z]+");
                                var hasMinimum8Chars = new Regex(@".{8,}");
                                PassError = "Password must contain 1 number, 1 Uppercase and at least 8 characters.";
                                isvalidated = hasNumber.IsMatch(Password) && hasUpperChar.IsMatch(Password) && hasMinimum8Chars.IsMatch(Password);
                            }
                         
                            break;
                        }
                     
                }
                return NameError;
            }
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}