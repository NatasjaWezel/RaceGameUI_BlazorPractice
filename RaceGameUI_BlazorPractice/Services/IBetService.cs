using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IBetService
    {

        public BetViewModel? GetBet(BettorViewModel bettor, GreyHoundViewModel greyHound, int investment);
        public Task<BetViewModel?> GetRandomBet(BettorViewModel bettor);


        // Place Random Bet

        // Get Description

        // Collect

        // Clear Bet
    }
}
