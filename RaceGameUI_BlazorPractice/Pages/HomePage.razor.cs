using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Web.Services;

namespace RaceGameUI_BlazorPractice.Web.Pages
{
    public partial class HomePage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IBettorService BettorService { get; set; }

        [Inject]
        public IGreyHoundService GreyHoundService { get; set; }

        private List<BettorViewModel> bettors;
        private List<GreyHoundViewModel> greyHounds;
        private string newPlayerName = "";
        private int newPlayerStartCash = 50;

        protected override async Task OnInitializedAsync()
        {
            bettors = await BettorService.GetBettorsAsync();
            greyHounds = await GreyHoundService.GetGreyHoundsAsync();
        }

        public async void StartRace()
        {
            // start race
            // when ended, calculate bet results
        }

        public async Task ResetRace()
        {
        }

        public async void PlaceRandomBet()
        {
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