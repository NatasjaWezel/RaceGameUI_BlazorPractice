using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Dal;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class GreyHoundService : IGreyHoundService
    {
        private readonly IGreyHoundRepository _greyHoundRepository;
        public List<GreyHoundViewModel>? GreyHounds;

        private Random _random;
        
        public GreyHoundService(IGreyHoundRepository greyhoundRepository)
        {
            _greyHoundRepository = greyhoundRepository;
            _random = new Random();
        }
        
        public Task<List<GreyHoundViewModel>> GetGreyHoundsAsync()
        {
            if (GreyHounds == null)
            {
                // the repo in .dal gets the data
                var entityModel = _greyHoundRepository.GetGreyHounds("C:\\Users\\UNATWE\\OneDrive - Van Lanschot Kempen\\Documents\\RaceGameUI_BlazorPractice\\RaceGameUI_BlazorPractice.Dal\\Data\\greyhounds.csv");

                // map to gui model
                GreyHounds = entityModel.Select(m => new GreyHoundViewModel { Id = m.Id, Name = m.Name}).ToList();
            }

            return Task.FromResult(GreyHounds);
        }

        public List<GreyHoundViewModel> GetGreyHounds()
        {
            return GreyHounds;
        }

        public async Task RunAsync(int whichDog)
        {
            // run between 1 and 4 spaces at random
            int addToPos = _random.Next(1, 5);

            var hound = GreyHounds[whichDog % GreyHounds.Count];

            // make sure hound doesn't run further than the finish
            if (hound.CurrentPosition + addToPos >= RaceTrackService.trackLength)
            {
                hound.CurrentPosition = RaceTrackService.trackLength;
                hound.finished = true;
            }
            else
            {
                hound.CurrentPosition += addToPos;
            }
        }

        public bool AreDogsFinished()
        {
            foreach (var hound in GreyHounds)
            {
                if (!hound.finished)
                {
                    return false;
                }
            }

            return true;
        }

        public void TakeDogsToStart()
        {
            foreach (var hound in GreyHounds)
            {
                hound.CurrentPosition = 0;
                hound.finished = false;
                hound.hideMedal1 = true;
                hound.hideMedal2 = true;
                hound.hideMedal3 = true;
            }
        }
    }
}
