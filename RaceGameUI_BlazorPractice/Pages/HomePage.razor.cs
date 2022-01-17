using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Pages
{
    public partial class HomePage
    {
        SimulateRace simulator = new SimulateRace();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async void startRace()
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
            simulator.CalculateBetResult(winningDogNumber);

            StateHasChanged();

            LocalData.RaceNumber++;
        }

        public async Task ResetRace()
        {
            simulator.TakeDogsToStart();

            Debug.Print("Took dogs to the start of the race track.");

            await InvokeAsync(StateHasChanged);
        }

        public async Task RunRaceStep(int dogNumber)
        {
            simulator.SimulateStep(dogNumber % LocalData.AmountGreyHounds);
            Debug.Print((dogNumber % LocalData.AmountGreyHounds).ToString() + ": " + LocalData.hounds[dogNumber % LocalData.AmountGreyHounds].GetCurrentPosition().ToString());

            await InvokeAsync(StateHasChanged);
            await Task.Delay(1);
        }

        public void PlaceRandomBet()
        {
            foreach (var bettor in LocalData.bettors)
            {
                // check if zero as not to overwrite handplaced bets
                if (bettor.Value.GetBet().GetAmount() == "-")
                {
                    bettor.Value.PlaceRandomBet();
                }
            }   
        }

        public void GoToHistoryPage()
        {
            NavigationManager.NavigateTo("bet_history");
            Debug.Print("Todo");
        }

        public void PlaceBet()
        {
            LocalData.bettors[LocalData.BettorName].PlaceBet(LocalData.Amount, LocalData.DogNumber);
        }

        public void CreateBettor()
        {
            LocalData.bettors[LocalData.NewPlayerName] = new Bettor(LocalData.NewPlayerName, LocalData.NewPlayerStartCash);

        }
    }   
}