using System;
using System.ComponentModel;

namespace Imi.Project.WPF.ViewModels
{
    public class AddBirdViewModel : INotifyPropertyChanged, IDataErrorInfo
    {

        public AddBirdViewModel()
        {
            HatchDate = DateTime.Now;
            CanAdd = true;

        }

        private bool canAdd;

        public bool CanAdd
        {
            get { return canAdd; }
            set
            {

                canAdd = value;
            }
        }

        private DateTime hatchDate;

        public DateTime HatchDate
        {
            get { return hatchDate; }
            set
            {

                hatchDate = value;
                RaisePropertyChanged(nameof(HatchDate));
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {

                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string test = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        test = "Name is Required";
                }
                if (columnName == "CanAdd")
                {
                    if (test != null)
                    {
                        CanAdd = false;
                    }
                }
                if (columnName == "HatchDate")
                {
                    if (HatchDate.Date > DateTime.Now.Date)
                        return "Hatch date can not be greater than today";
                }
                return test;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
