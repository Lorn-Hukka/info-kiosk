using Prism.Regions;
using System;
using System.Threading.Tasks;
using InfoKiosk.Desktop.ImagePresentation.Model;

namespace InfoKiosk.Desktop.ImagePresentation.Services
{
    internal class PresentationController
    {
        private readonly IRegionManager _regionManager;
        private readonly SlideRepository _slideRepository;

        private Slide? _currentSlide = null;

        public PresentationController(IRegionManager regionManager, SlideRepository slideRepository)
        {
            _regionManager = regionManager;
            _slideRepository = slideRepository;
        }

        public async Task Next(Action<NavigationResult> navigationCallback)
        {
            if (_currentSlide is null)
            {
                _currentSlide = await _slideRepository.GetFirst();
                return;
            }
            _currentSlide = await _slideRepository.GetNext(_currentSlide);
            _regionManager.RequestNavigate(
                "PresentationSlideRegion", 
                "ImagePresentationSlideView", 
                navigationCallback,
                new NavigationParameters { { "slide", _currentSlide } }
            );
        }

        public async Task Previous(Action<NavigationResult> navigationCallback)
        {
            if (_currentSlide is null)
            {
                return;
            }

            _currentSlide = await _slideRepository.GetPrevious(_currentSlide);
            _regionManager.RequestNavigate(
                "PresentationSlideRegion", 
                "ImagePresentationSlideView", 
                navigationCallback,
                new NavigationParameters { { "slide", _currentSlide } }
            );
        }
    }
}
