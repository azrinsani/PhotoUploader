using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AzUtil.Core;
using photouploader.Core;
using Xamarin.Essentials;

namespace photouploader
{
    public class AppService : IAppService
    {
        public AppService()
        {
        }

        public async Task<FileResult> PickPhotoAsync()
        {
            try
            {
                FileResult photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                return photo;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }

            return null;
        }
        
        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            await using var stream = await photo.OpenReadAsync();
            await using var newStream = File.OpenWrite(newFile);
            await stream.CopyToAsync(newStream);

        }
    }

}