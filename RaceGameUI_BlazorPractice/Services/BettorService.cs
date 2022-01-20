using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Model;
using RaceGameUI_BlazorPractice.Dal;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BettorService: IBettorService
    {
        private readonly IBettorRepository _bettorRepository;
        private BettorViewModel[]? _bettors;

        public BettorService(IBettorRepository bettorRepository)
        {
            _bettorRepository = bettorRepository;
        }

        public Task<BettorViewModel[]> GetBettorsAsync()
        {
            if (_bettors == null)
            {
                // the repo in .dal gets the data
                var entityModel = _bettorRepository.GetBettors("bettors.csv");

                // map to gui model
                _bettors = entityModel.Select(m => new BettorViewModel { Name = m.Name, StartingCash = m.StartingCash, CurrentCash = m.CurrentCash}).ToArray();
            }

            return Task.FromResult(_bettors);
        }

        public async Task PlaceRandomBetsAsync()
        {
            //foreach (var bettor in _bettors)
            //{
            //    // check if zero as not to overwrite handplaced bets
            //    if (bettor.GetBet().GetAmount() == "-")
            //    {
            //        bettor.PlaceRandomBet();
            //    }
            //}
        }

        public async Task PlaceBetAsync()
        {

        }

        public void CalculateBetResult(int winningDogNumber)
        {
            //    foreach (var bettor in _bettors)
            //    {
            //        bettor.Collect(winningDogNumber);
            //        bettor.ClearBet();
            //    }
        }
}
}
