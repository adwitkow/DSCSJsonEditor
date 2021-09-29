using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSCSJsonEditor.WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T propertyReference, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(propertyReference, newValue))
            {
                return false;
            }

            propertyReference = newValue;

            this.NotifyPropertyChanged(propertyName);

            return true;
        }
    }
}
