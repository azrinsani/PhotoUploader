using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AzUtil.Core;
using FreshMvvm;

namespace photouploader
{
    public class MainPageModel:FreshBasePageModel
    {
        public MainPageModel()
        {
            this.Photos.CollectionChanged += (_, _) =>
            {
                RaisePropertyChanged(nameof(this.NextButtonEnabled));
            };
        }

        private IAppService _appService => _appServiceBackingField ?? FreshIOC.Container.Resolve<IAppService>();
        private readonly IAppService _appServiceBackingField = null;
        public ObservableCollection<PhotoVM> Photos { get; set; } = new();

        public ICommand AddPhotoCommand => new AzCommand(async () =>
        {
            var photo = await _appService.PickPhotoAsync();
            if (photo == null) return;
            this.Photos.Add(new PhotoVM(photo.FullPath));
        });

        public bool IncludeInPhotoGallery
        {
            get => includeInPhotoGallery;
            set
            {
                if (includeInPhotoGallery != value)
                {
                    includeInPhotoGallery = value;
                    RaisePropertyChanged(nameof(IncludeInPhotoGallery));
                }
            }
        }
        private bool includeInPhotoGallery;

        public string Comments
        {
            get => comments;
            set
            {
                if (comments != value)
                {
                    comments = value;
                    RaisePropertyChanged(nameof(Comments));
                }
            }
        }
        private string comments;

        public DateTime DateUtc
        {
            get => dateUtc;
            set
            {
                if (dateUtc != value)
                {
                    dateUtc = value;
                    RaisePropertyChanged(nameof(DateUtc));
                }
            }
        }
        private DateTime dateUtc;


        public string ActivityText
        {
            get => activityText;
            set
            {
                if (activityText != value)
                {
                    activityText = value;
                    RaisePropertyChanged(nameof(ActivityText));
                }
            }
        }
        private string activityText;

        public bool LinkToExistingEvent
        {
            get => linkToExistingEvent;
            set
            {
                if (linkToExistingEvent != value)
                {
                    linkToExistingEvent = value;
                    RaisePropertyChanged(nameof(LinkToExistingEvent));
                }
            }
        }
        private bool linkToExistingEvent;


        public bool ShowActivityIndicator
        {
            get => showActivityIndicator;
            set
            {
                if (showActivityIndicator != value)
                {
                    showActivityIndicator = value;
                    RaisePropertyChanged(nameof(ShowActivityIndicator));
                }
            }
        }
        private bool showActivityIndicator;

        public bool ShowSpinner
        {
            get => showSpinner;
            set
            {
                if (showSpinner != value)
                {
                    showSpinner = value;
                    RaisePropertyChanged(nameof(ShowSpinner));
                }
            }
        }
        private bool showSpinner;
        
        
        public bool NextButtonEnabled => this.Photos.Count > 0;


        public ICommand NextCommand => new AzCommand(async () =>
        {
            this.ActivityText = "Uploading";
            this.ShowSpinner = true;
            this.ShowActivityIndicator = true;
            try
            {
                await _appService.Upload(this.Photos);
                this.ActivityText = "Success!";
            }
            catch
            {
                this.ActivityText = "Failed!";
            }
            this.ShowSpinner = false;
            await Task.Delay(2000);
            this.Photos.Clear();
            this.ShowActivityIndicator = false;
        });


    }

    public class DummyPost
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}