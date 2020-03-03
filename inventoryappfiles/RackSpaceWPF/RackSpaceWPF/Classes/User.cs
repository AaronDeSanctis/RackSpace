using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RackSpaceWPF.Classes
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Guid guid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private bool IsAuth { get; set; }
        private Visibility btnVis { get; set; }
        public bool IsAuthenticated
    {
            get
            {
                return this.IsAuth;
            }

            set
            {
                if (value != this.IsAuth)
                {
                    this.IsAuth = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Visibility BtnVis
        {
            get
            {
                return this.btnVis;
            }

            set
            {
                if (value != this.btnVis)
                {
                    this.btnVis = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public void ChooseGuid()
        {
            guid = Guid.NewGuid();
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Visibility DetermineVisibility()
        {
            if (IsAuthenticated == true)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
