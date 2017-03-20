using System;
using System.ComponentModel;

namespace EditCollection.Models
{
    [Serializable]//Этот атрибут нужен, чтобы работало копирование объекта.
    public class OperationView : INotifyPropertyChanged
    {
        private bool _isActive;
        private string _viewName;
        private string _owner;
        private string _department;
        private string _description;
        private string _alarms;

        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropetyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive == value)
                    return;
                _isActive = value;
                RaisePropetyChanged("isActive");
            }
        }
        public string ViewName
        {
            get { return _viewName; }
            set
            {
                if (_viewName == value)
                    return;
                _viewName = value;
                RaisePropetyChanged("ViewName");
            }
        }
        public string Owner
        {
            get { return _owner; }
            set
            {
                if (_owner == value)
                    return;
                _owner = value;
                RaisePropetyChanged("Owner");
            }
        }
        public string Department
        {
            get { return _department; }
            set
            {
                if (_department == value)
                    return;
                _department = value;
                RaisePropetyChanged("Department");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                    return;
                _description = value;
                RaisePropetyChanged("Description");
            }
        }
        public string Alarms
        {
            get { return _alarms; }
            set
            {
                if (_alarms == value)
                    return;
                _alarms = value;
                RaisePropetyChanged("Alarms");
            }
        }
    }
}
