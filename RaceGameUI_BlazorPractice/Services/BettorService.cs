using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Dal;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BettorService : IBettorService
    {
        private readonly IBettorRepository _bettorRepository;
        private List<BettorViewModel>? _bettors;

        private readonly IBetService _betService;
        private readonly IGreyHoundService _greyHoundService;

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
                var entityModel = _bettorRepository.GetBettors("C:\\Users\\UNATWE\\OneDrive - Van Lanschot Kempen\\Documents\\RaceGameUI_BlazorPractice\\RaceGameUI_BlazorPractice.Dal\\Data\\bettors.csv");
                _bettors = entityModel.Select(m => new BettorViewModel { Name = m.Name, StartingCash = m.StartingCash, CurrentCash = m.CurrentCash }).ToList();
            }

            return Task.FromResult(_bettors);
        }

        public async Task PlaceRandomBetsAsync()
        {
            foreach (var bettor in await GetBettorsAsync())
            {
                // don't overwrite bets that are already placed
                if (bettor.MyBet == null)
                {
                    bettor.MyBet = await _betService.GetRandomBet(bettor);
                    if (bettor.MyBet != null)
                    {
                        Debug.Print($"Placing a random bet for {bettor.Name}: {bettor.MyBet.Amount} bucks on {bettor.MyBet.DogId}");
                    } else
                    {
                        Debug.Print($"{bettor.Name} is broke and can't bet anymore.");
                    }
                    
                }
            }
        }

        public async Task PlaceBetAsync(string name, int dogNumber, int amount)
        {
            foreach (var bettor in await GetBettorsAsync())
            {
                if (bettor.Name == name)
                {
                    bettor.MyBet = _betService.GetBet(bettor, await _greyHoundService.GetGreyHound(dogNumber), amount);
                }
            }
        }

        public async Task CollectPayout()
        {
            foreach (var bettor in await GetBettorsAsync())
            {
                if (bettor.MyBet != null)
                {
                    var hound = await _greyHoundService.GetGreyHound(bettor.MyBet.DogId);

                    if (hound.finishPosition != null)
                    {
                        bettor.CurrentCash += (int)hound.finishPosition * bettor.MyBet.Amount;
                    }
                    else
                    {
                        bettor.CurrentCash -= bettor.MyBet.Amount;
                    }

                }
                // reset bet
                bettor.MyBet = null;
            }
        }
    }
}
