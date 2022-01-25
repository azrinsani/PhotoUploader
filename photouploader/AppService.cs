using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using azutil_core;
using Xamarin.Essentials;

namespace photouploader
{
    public class AppService : IAppService
    {
        public AppService()
        {
        }

        public async Task Upload(IEnumerable<PhotoVM> photos)
        {
            foreach (var photo in photos)
            {
                var bytes = await File.ReadAllBytesAsync(photo.FullPath);
                var base64Str = Convert.ToBase64String(bytes);
                var json = new DummyPost()
                {
                    name = "image",
                    job = base64Str.Substring(1,20)
                }.ToSerializedString();
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await Services.HttpClient.PostAsync(
                    "https://reqres.in/api/users", content);
                if (!res.IsSuccessStatusCode) throw new HttpRequestException();
            }
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