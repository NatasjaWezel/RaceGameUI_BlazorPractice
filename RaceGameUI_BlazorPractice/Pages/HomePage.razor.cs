using Microsoft.AspNetCore.Components;
using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Web.Services;

namespace RaceGameUI_BlazorPractice.Web.Pages
{
    public partial class HomePage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IBettorService Bettors { get; set; }

        [Inject]
        public IGreyHoundService GreyHounds { get; set; }

        [Inject]
        public IRaceTrackService RaceTrack { get; set; }

        private List<BettorViewModel> bettors;
        private List<GreyHoundViewModel> greyHounds;
        private string newPlayerName = "";
        private int newPlayerStartCash = 50;

        protected override async Task OnInitializedAsync()
        {
            bettors = await Bettors.GetBettorsAsync();
            greyHounds = await GreyHounds.GetGreyHoundsAsync();
        }

        public async void StartRace()
        {
            // start race
            RaceTrack.SimulateRace();
            // when ended, calculate bet results
        }

        public async Task ResetRace()
        {
        }

        public async void PlaceRandomBet()
        {
            await Bettors.PlaceRandomBetsAsync();
        }

        public void GoToHistoryPage()
        {
            NavigationManager.NavigateTo("bet_history");
        }

        public void PlaceBet()
        {
        }

        public void CreateBettor()
        {
        }
    }   
}