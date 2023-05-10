using System.IO;
using Avalonia.Media.Imaging;
using InfoKiosk.Desktop.ImagePresentation.Model;
using Prism.Mvvm;
using Prism.Regions;

namespace InfoKiosk.Desktop.ImagePresentation.ViewModels
{
    internal class ImagePresentationSlideViewModel: BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get => _title;
            private set => SetProperty(ref _title, value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            private set => SetProperty(ref _description, value);
        }

        private Bitmap _image;

        public Bitmap Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["slide"] is not Slide slide)
                return;

            Title = slide.Title;
            Description = slide.Description;

            if (!File.Exists(slide.Source))
                return;

            Image = new Bitmap(slide.Source);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return navigationContext.Parameters["slide"] is Slide;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
