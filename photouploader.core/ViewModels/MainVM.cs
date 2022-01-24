using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AzUtil.Core;
using azutil_core;

namespace photouploader.Core.ViewModels
{
    public class MainVM:BaseViewModel
    {
        public MainVM()
        {
            this.Photos.CollectionChanged += (sender, args) =>
            {
                this.OnPropertyChanged(nameof(this.NextButtonEnabled));
            };
        }

        public void Initialize()
        {
            Services.DeviceService.SetTopStatusBar(Color.FromHex("#000000"));
            
        }
        public ObservableCollection<PhotoVM> Photos { get; set; } = new();

        public ICommand AddPhotoCommand => new AzCommand(async () =>
        {
            var photo = await Services.AppService.PickPhotoAsync();
            if (photo == null) return;
            this.Photos.Add(new PhotoVM()
            {
                FullPath =  photo.FullPath
            });
           
        });
        
        public bool IncludeInPhotoGallery { get => includeInPhotoGallery;
            set => SetProperty(ref includeInPhotoGallery, value); }
        private bool includeInPhotoGallery;
        
        public string Comments { get => comments;
            set => SetProperty(ref comments, value); }
        private string comments;
        
        public DateTime DateUtc { get => dateUtc;
            set => SetProperty(ref dateUtc, value); }
        private DateTime dateUtc;
        
        public string Tags { get => tags;
            set => SetProperty(ref tags, value); }
        private string tags;
         public string ActivityText { get => activityText;
            set => SetProperty(ref activityText, value); }
        private string activityText;
        
        public bool LinkToExistingEvent { get => linkToExistingEvent;
            set => SetProperty(ref linkToExistingEvent, value); }
        private bool linkToExistingEvent;
        
          
        public bool ShowActivityIndicator { get => showActivityIndicator;
            set => SetProperty(ref showActivityIndicator, value); }
        private bool showActivityIndicator;
        public bool ShowSpinner { get => showSpinner;
            set => SetProperty(ref showSpinner, value); }
        private bool showSpinner;
        
        
        public bool NextButtonEnabled => this.Photos.Count > 0;


        public ICommand NextCommand => new AzCommand(async () =>
        {
            this.ActivityText = "Uploading";
            this.ShowSpinner = true;
            this.ShowActivityIndicator = true;
            foreach (var photo in this.Photos)
            {
                var bytes = File.ReadAllBytes(photo.FullPath);
                var base64Str = Convert.ToBase64String(bytes);
                var json = new DummyPost()
                {
                    name = "image",
                    job = base64Str
                }.ToSerializedString();
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await Services.HttpClient.PostAsync(
                    "https://reqres.in/api/users", content);
            }
            this.ActivityText = "Success!";
            this.ShowSpinner = false;
            await Task.Delay(2000);
            this.ShowActivityIndicator = false;
        });


    }

    public class DummyPost
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}