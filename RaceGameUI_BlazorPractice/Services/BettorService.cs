using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Dal;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BettorService: IBettorService
    {
        private readonly IBettorRepository _bettorRepository;
        private List<BettorViewModel>? _bettors;

        private IBetService _betService;
        private IGreyHoundService _greyHoundService;

        public BettorService(IBettorRepository bettorRepository, IBetService betService, IGreyHoundService greyHoundService)
        {
            _bettorRepository = bettorRepository;
            _betService = betService;
            _greyHoundService = greyHoundService;
        }

        public Task<List<BettorViewModel>> GetBettorsAsync()
        {
            if (_bettors == null)
            {
                // the repo in .dal gets the data
                var entityModel = _bettorRepository.GetBettors("C:\\Users\\UNATWE\\OneDrive - Van Lanschot Kempen\\Documents\\RaceGameUI_BlazorPractice\\RaceGameUI_BlazorPractice.Dal\\Data\\bettors.csv");

                // map to gui model
                _bettors = entityModel.Select(m => new BettorViewModel { Name = m.Name, StartingCash = m.StartingCash, CurrentCash = m.CurrentCash}).ToList();
            }

            return Task.FromResult(_bettors);
        }

        public async Task PlaceRandomBetsAsync()
        {
            foreach (var bettor in await GetBettorsAsync())
            {
                if (bettor.MyBet == null)
                {
                    Debug.Print("Placing random bet for: " + bettor.Name);
                    bettor.MyBet = await _betService.GetRandomBet(bettor);
                } else
                {
                    Debug.Print(bettor.Name + "already placed a bet.");
                }
            }
        }

        public async Task PlaceBetAsync(string name, int dogNumber, int amount)
        {
            foreach (var bettor in await GetBettorsAsync())
            {
                if (bettor.Name == name)
                {
                    bettor.MyBet = _betService.GetBet(bettor, _greyHoundService.GetGreyHound(dogNumber), amount);
                }
            }
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
