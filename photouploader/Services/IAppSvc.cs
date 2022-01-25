using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace photouploader
{
    public interface IAppService
    {
        Task<FileResult> PickPhotoAsync();
        Task Upload(IEnumerable<PhotoVM> photos);
    };
}
