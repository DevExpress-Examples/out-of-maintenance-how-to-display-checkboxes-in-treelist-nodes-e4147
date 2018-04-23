using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace TreeListCheckBoxes
{
    public class Person : INotifyPropertyChanged
    {
        bool isChecked;
        string firstName, lastName;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (IsChecked == value)
                    return;
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (FirstName == value)
                    return;
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (LastName == value)
                    return;
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
