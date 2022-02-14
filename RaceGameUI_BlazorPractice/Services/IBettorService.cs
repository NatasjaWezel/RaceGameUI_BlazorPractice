using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IBettorService
    {
        Task<List<BettorViewModel>> GetBettorsAsync();

        Task PlaceRandomBetsAsync();
        Task PlaceBetAsync(string name, int dogNumber, int amount);

        public void CalculateBetResult(int winningDogNumber);


    }
}
