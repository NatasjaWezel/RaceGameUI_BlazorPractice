using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using RaceGameUI_BlazorPractice.Web.Models;
using RaceGameUI_BlazorPractice.Web.Services;

namespace RaceGameUI_BlazorPractice.Web.Pages
{
    public partial class HomePage
    {
        SimulateRace simulator = new();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IBettorService BettorService { get; set; }

        private BettorViewModel[] bettors;

        protected override async Task OnInitializedAsync()
        {
            bettors = await BettorService.GetBettorsAsync();
        }

        public async void StartRace()
        {
            await ResetRace();
            int dogNumber = 0;

            Debug.Print("Now running simulation #" + LocalData.RaceNumber);
            while (!simulator.RaceEnded())
            {
                await RunRaceStep(dogNumber);

                Thread.Sleep(5);
                dogNumber++;
            }

            int winningDogNumber = (dogNumber - 1) % LocalData.AmountGreyHounds + 1;

            BettorService.CalculateBetResult(winningDogNumber);

            StateHasChanged();

            LocalData.RaceNumber++;
        }

        public async Task ResetRace()
        {
            simulator.TakeDogsToStart();

            await InvokeAsync(StateHasChanged);
        }

        public async Task RunRaceStep(int dogNumber)
        {
            simulator.SimulateStep(dogNumber % LocalData.AmountGreyHounds);

            await InvokeAsync(StateHasChanged);
            await Task.Delay(1);
        }

        public async void PlaceRandomBet()
        {
            StateHasChanged();
        }

        public void GoToHistoryPage()
        {
            NavigationManager.NavigateTo("bet_history");
            Debug.Print("Todo");
        }

        public void PlaceBet()
        {
            StateHasChanged();
        }

        public void CreateBettor()
        {
        }
    }   
}