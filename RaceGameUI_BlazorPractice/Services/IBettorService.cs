using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IBettorService
    {
        Task<BettorViewModel[]> GetBettorsAsync();

        Task PlaceRandomBetsAsync();
        Task PlaceBetAsync();

        public void CalculateBetResult(int winningDogNumber);


    }
}
