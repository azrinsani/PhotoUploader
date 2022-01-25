using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AzUtil.Core;
using System.Windows.Input;
using azutil_core;

namespace photouploader.Core.ViewModels
{
    public class PhotoVM:BaseViewModel
    {
        public PhotoVM()
        {
            
        }
        public string FullPath { get => fullPath;
            set => SetProperty(ref fullPath, value); }
        private string fullPath;

        public PhotoVM(string fullPath) : this()
        {
            FullPath = fullPath;
        }

        public ICommand DeleteCommand => new AzCommand(() =>
        {
            Services.MainVM.Photos.RemoveWhere(e => e == this);
        });
        
    }
}