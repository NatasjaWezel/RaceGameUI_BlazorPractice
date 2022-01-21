using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Dal;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class GreyHoundService : IGreyHoundService
    {
        private readonly IGreyHoundRepository _greyHoundRepository;
        public List<GreyHoundViewModel>? GreyHounds;
        
        public GreyHoundService(IGreyHoundRepository greyhoundRepository)
        {
            _greyHoundRepository = greyhoundRepository;
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

        public Task RunAsync()
        {
            //    // run between 1 and 4 spaces at random
            //    int addToPos = _randomizer.Next(1, 5);

            //    // make sure hound doesn't run further than the finish
            //    if (_currentPosition + addToPos >= LocalData.RaceTrackLength)
            //    {
            //        _currentPosition = LocalData.RaceTrackLength;
            //    }
            //    else
            //    {
            //        _currentPosition += addToPos;
            //    }
            throw new NotImplementedException();
        }
    }
}
