using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace photouploader.Core.ViewModels
{
    
    public interface IOnPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
    
    public class BaseViewModel : INotifyPropertyChanged, IOnPropertyChanged
    {


        #region INotifyPropertyChanged

        [DebuggerStepThrough]
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = null, Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        [DebuggerStepThrough]
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
    }
}