using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BetService: IBetService
    {
        public static int minBet = 5;
        public static int maxBet = 1000;

        private IGreyHoundService _greyHoundService;

        public BetService(IGreyHoundService greyHoundService)
        {
            _greyHoundService = greyHoundService;
        }

        public BetViewModel GetBet(BettorViewModel bettor, int dogNumber, int investment)
        {
            if (investment <= bettor.CurrentCash)
            {
                return new BetViewModel(dogNumber, investment);
            }
            return new BetViewModel();
        }

        public BetViewModel GetRandomBet(BettorViewModel bettor)
        {
            Random rand = new Random();
            if (bettor.CurrentCash >= RaceTrackService.minInvestment)
            {
                return GetBet(bettor,
                         rand.Next(RaceTrackService.minInvestment, bettor.CurrentCash), 
                         rand.Next(1, _greyHoundService.GetGreyHounds().Count));
            }
            return new BetViewModel();
        }

        //    public void Collect(int WinnerDogNumber)
        //    {
        //        CurrentCash += MyBet.PayOut(WinnerDogNumber);
        //    }

    }
}
