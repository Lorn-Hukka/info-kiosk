using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoKiosk.Client;
using InfoKiosk.Desktop.ImagePresentation.Model;

namespace InfoKiosk.Desktop.ImagePresentation.Services
{
    internal class SlideRepository
    {
        private readonly IClient _client;

        private List<Slide> _slides = new List<Slide>
        {
            new Slide("abc", SlideType.Image, SourceFrom.File, "test.bmp", "Test", "Test description"),
            new Slide("abc", SlideType.Image, SourceFrom.File, "test2.bmp", "Test2", "Test2 description")
        };

        public SlideRepository(IClient client)
        {
            _client = client;
        }

        public async Task<Slide?> GetFirst()
        {
            _slides = (await _client.GetAllAsync<Slide>("slides")).ToList();

            return _slides.Count == 0 
                ? null
                : _slides?[0];
        }

        public async Task<Slide?> GetNext(Slide? slide)
        {
            if (slide is null)
                return default;

            var currentIndex = _slides.IndexOf(slide);
            if (currentIndex < 0)
                return await GetFirst();

            var nextIndex = ++currentIndex;
            if (nextIndex >= _slides.Count)
                nextIndex = 0;

            return await GetByIndex(nextIndex);
        }

        public async Task<Slide?> GetPrevious(Slide? slide)
        {
            if (slide is null)
                return default;

            var currentIndex = _slides.IndexOf(slide);
            if (currentIndex < 0)
                return await GetFirst();

            var nextIndex = --currentIndex;
            if (nextIndex < 0)
                nextIndex = _slides.Count - 1;

            return await GetByIndex(nextIndex);
        }

        private Task<Slide?> GetByIndex(int index)
        {
            return index < _slides.Count
                ? Task.FromResult(_slides[index])
                : Task.FromResult<Slide?>(null);
        }
    }
}
