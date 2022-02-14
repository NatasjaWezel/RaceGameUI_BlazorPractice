using RaceGameUI_BlazorPractice.Web.Models;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BetService: IBetService
    {
        public static int minBet = 5;
        public static int maxBet = 15;

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
                return await Task.Run(() => GetBet(bettor,
                                                    _greyHoundService.GetGreyHound(rand.Next(1, 8)),
                                                    rand.Next(RaceTrackService.minInvestment, RaceTrackService.maxInvestment)));
            }
            Debug.Print($"GetRandomBet returns null {bettor.CurrentCash}, {RaceTrackService.minInvestment}");
            return null;
        }

        //    public void Collect(int WinnerDogNumber)
        //    {
        //        CurrentCash += MyBet.PayOut(WinnerDogNumber);
        //    }

    }
}
