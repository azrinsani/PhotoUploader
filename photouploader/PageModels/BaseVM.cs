using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FreshMvvm;

namespace photouploader
{
    
    public class BaseViewModel : FreshBasePageModel
    {


        #region INotifyPropertyChanged

        [DebuggerStepThrough]
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = null, Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }
        

        #endregion
    }
}