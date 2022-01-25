using AzUtil.Core;
using System.Windows.Input;
using azutil_core;

namespace photouploader
{
    public class PhotoVM:BaseViewModel
    {
        private PhotoVM(MainPageModel mainPageModel)
        {
            _mainPageModel = mainPageModel;
        }

        private readonly MainPageModel _mainPageModel;
        public string FullPath { get => fullPath;
            set => SetProperty(ref fullPath, value); }
        private string fullPath;

        public PhotoVM(string fullPath, MainPageModel mainPageModel=null) : this(mainPageModel)
        {
            FullPath = fullPath;
        }


        public ICommand DeleteCommand => new AzCommand(() =>
        {
            _mainPageModel.Photos.RemoveWhere(e => e == this);
        });
        
    }
}