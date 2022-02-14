using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Dal;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class GreyHoundService : IGreyHoundService
    {
        private readonly IGreyHoundRepository _greyHoundRepository;
        public List<GreyHoundViewModel>? _greyHounds;

        public event Action? OnDogStep;

        private Random _random;
        private int _noDogsFinished;
        
        public GreyHoundService(IGreyHoundRepository greyhoundRepository)
        {
            _greyHoundRepository = greyhoundRepository;
            _random = new Random();
        }
        
        public Task<List<GreyHoundViewModel>> GetGreyHoundsAsync()
        {
            if (_greyHounds == null)
            {
                // the repo in .dal gets the data
                var entityModel = _greyHoundRepository.GetGreyHounds(@"C:\Users\UNATWE\OneDrive - Van Lanschot Kempen\Documents\RaceGameUI_BlazorPractice\RaceGameUI_BlazorPractice.Dal\Data\greyhounds.csv");

                // map to gui model
                _greyHounds = entityModel.Select(m => new GreyHoundViewModel { Id = m.Id, Name = m.Name}).ToList();
            }

            return Task.FromResult(_greyHounds);
        }

        public async Task RunAsync(int dogId)
        {
            // run between 1 and 4 spaces at random
            int addToPos = _random.Next(1, 5);

            var hounds = await GetGreyHoundsAsync();
            var hound = hounds[dogId % hounds.Count];

            // make sure hound doesn't run further than the finish
            if (hound.finished == false && hound.CurrentPosition + addToPos >= RaceTrackService.trackLength)
            {
                hound.CurrentPosition = RaceTrackService.trackLength;
                hound.finished = true;
                await Task.Run(() => HandOutMedal(hound));
            }
            else if (hound.finished == false)
            {
                Debug.Print($"Dog id: {hound.Id} Current pos: {hound.CurrentPosition}");
                hound.CurrentPosition += addToPos;
            }
            // a dog ran a step, so notify the blazor component
            OnDogStep?.Invoke();
        }

        private void HandOutMedal(GreyHoundViewModel hound)
        {
            if (_noDogsFinished == 0)
            {
                hound.hideMedal1 = false;
            } else if (_noDogsFinished == 2)
            {
                hound.hideMedal2 = false;
            } else if (_noDogsFinished == 1)
            {
                hound.hideMedal3 = false;
            }

            _noDogsFinished++;
        }

        public async Task<bool> AreDogsFinished()
        {
            foreach (var hound in await GetGreyHoundsAsync())
            {
                if (!hound.finished)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task TakeDogsToStart()
        {
            foreach (var hound in await GetGreyHoundsAsync())
            {
                hound.CurrentPosition = 0;
                hound.finished = false;
                hound.hideMedal1 = true;
                hound.hideMedal2 = true;
                hound.hideMedal3 = true;
            }
        }

        public async Task<GreyHoundViewModel> GetGreyHound(int id)
        {
            var hounds = await GetGreyHoundsAsync();
            return hounds[id];
        }

        public string GetGreyHoundName(int id)
        {
            return _greyHounds[id].Name;
        }
    }
}
