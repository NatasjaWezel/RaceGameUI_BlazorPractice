using RaceGameUI_BlazorPractice.Web.Models;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BetService: IBetService
    {
        private IGreyHoundService _greyHoundService;

        public BetService(IGreyHoundService greyHoundService)
        {
            _greyHoundService = greyHoundService;
        }

        public BetViewModel? GetBet(BettorViewModel bettor, GreyHoundViewModel greyHound, int investment)
        {
            if (investment <= bettor.CurrentCash)
            {
                return new BetViewModel(greyHound.Id, investment);
            }
            return null;
        }

        public async Task<BetViewModel?> GetRandomBet(BettorViewModel bettor)
        {
            Random rand = new Random();
            if (bettor.CurrentCash >= RaceTrackService.minInvestment)
            {
                var hound = await _greyHoundService.GetGreyHound(rand.Next(1, 8));
                return await Task.Run(() => GetBet(bettor, hound,
                                                    rand.Next(RaceTrackService.minInvestment, bettor.CurrentCash)));
            }
            return null;
        }
    }
}
