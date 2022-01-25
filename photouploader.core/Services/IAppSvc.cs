using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using photouploader.Core.ViewModels;
using Xamarin.Essentials;

namespace photouploader.Core
{
    public interface IAppService
    {
        Task<FileResult> PickPhotoAsync();
        Task Upload(IEnumerable<PhotoVM> photos);
    };
}
