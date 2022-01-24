using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IBetService
    {

        public BetViewModel GetBet(BettorViewModel bettor, int dogNumber, int investment);
        public BetViewModel GetRandomBet(BettorViewModel bettor);


        // Place Random Bet

        // Get Description

        // Collect

        // Clear Bet
    }
}
