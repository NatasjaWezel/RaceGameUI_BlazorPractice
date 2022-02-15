using RaceGameUI_BlazorPractice.Dal;
using RaceGameUI_BlazorPractice.Web.Models;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class GreyHoundService : IGreyHoundService
    {
        private readonly IGreyHoundRepository _greyHoundRepository;
        public List<GreyHoundViewModel>? _greyHounds;

        private static int _noGreyHoundsFinished;

        public event Action? OnDogStep;

        private readonly Random _random;

        public GreyHoundService(IGreyHoundRepository greyhoundRepository)
        {
            _greyHoundRepository = greyhoundRepository;
            _random = new Random();
        }

        public Task<List<GreyHoundViewModel>> GetGreyHoundsAsync()
        {
            if (_greyHounds == null)
            {
                var entityModel = _greyHoundRepository.GetGreyHounds(@"..\RaceGameUI_BlazorPractice.Dal\Data\greyhounds.csv");
                _greyHounds = entityModel.Select(m => new GreyHoundViewModel { Id = m.Id, 
                                                                               Name = m.Name,
                                                                               initialPosition = m.initialPosition,
                                                                               currentPosition = m.currentPosition,
                                                                               finished = m.finished,
                                                                               finishPosition = m.finishPosition}).ToList();
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
            if (hound.finished == false && hound.currentPosition + addToPos >= RaceTrackService.trackLength)
            {
                hound.currentPosition = RaceTrackService.trackLength;
                hound.finished = true;
                await Task.Run(() => HandOutMedal(hound));
            }
            else if (hound.finished == false)
            {
                hound.currentPosition += addToPos;
            }
            // invoke action to refresh component
            OnDogStep?.Invoke();
        }

        private void HandOutMedal(GreyHoundViewModel hound)
        {
            if (_noGreyHoundsFinished == 0)
            {
                hound.finishPosition = 1;
                hound.hideMedal1 = false;
            }
            else if (_noGreyHoundsFinished == 1)
            {
                hound.finishPosition = 2;
                hound.hideMedal2 = false;
            }
            else if (_noGreyHoundsFinished == 2)
            {
                hound.finishPosition = 3;
                hound.hideMedal3 = false;
            }
            _noGreyHoundsFinished++;
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
                hound.currentPosition = 0;
                hound.finishPosition = null;
                hound.finished = false;
                hound.hideMedal1 = true;
                hound.hideMedal2 = true;
                hound.hideMedal3 = true;
            }
            _noGreyHoundsFinished = 0;
        }

        public async Task<GreyHoundViewModel> GetGreyHound(int id)
        {
            var hounds = await GetGreyHoundsAsync();
            return hounds[id];
        }

        public string GetGreyHoundName(int id)
        {
            // TODO: how to fix this warning?
            // "_greyHounds may be null here", "dereference of a possibly null reference", "possible null reference return"
            return _greyHounds[id].Name;
        }
    }
}
