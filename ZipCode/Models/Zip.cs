using System.ComponentModel;
using System.Text.RegularExpressions;
using ZipCode;

namespace ZipCode.Models
{
    class Zipcode : IDataErrorInfo, INotifyPropertyChanged  
    {
        private string zip = string.Empty;
        private string zipError;
        public bool isvalidated;

 

        


        public override string ToString()
        {
            return zip;
        }
        public string ZipError
        {
            get
            {
                return zipError;
            }
            set
            {
                if (zipError != value)
                {
                    zipError = value;
                    OnPropertyChanged("ZipError");
                }
            }
        }






        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                if (zip != value)
                {
                    zip = value;
                    OnPropertyChanged("Zip");
                }
            }
        }


        public bool ButtonEnabled
        {
            get
            {
                return isvalidated;
               
            }
            set
            {
                
                    isvalidated = value;
                    OnPropertyChanged("ButtonEnabled");
                

            }
        }



        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return ZipError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {
                ZipError = "";
               
         
                switch (columnName)
                {
                    case "Zip":
                        {
                            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
                            var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

                            if ((!Regex.Match(Zip, _usZipRegEx).Success) && (!Regex.Match(Zip, _caZipRegEx).Success))
                            {
                                ZipError = "Not valid US or Candian Zip Code";
                                ButtonEnabled = false;
                            }
                            else
                            {
                                ZipError = "Valid Zip Code Typed!";
                                ButtonEnabled = true;
                            }
                            break;
                        }
                 
                }
                return ZipError;
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