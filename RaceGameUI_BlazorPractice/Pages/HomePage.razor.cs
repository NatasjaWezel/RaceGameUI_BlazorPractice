using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Pages
{
    public partial class HomePage
    {
        public string curPosDog0 = "0";
        public string curPosDog1 = "0";
        public string curPosDog2 = "0";
        public string curPosDog3 = "0";

        SimulateRace simulator;

        public async void startRace()
        {
            simulator = new SimulateRace(); 
            int dogNumber = 0;

            while (!simulator.RaceEnded())
            {
                await RunRaceStep(dogNumber);

                Thread.Sleep(5);
                dogNumber++;
            }

            int winningDogNumber = (dogNumber - 1) % 4 + 1;
            simulator.CalculateBetResult(winningDogNumber);

            StateHasChanged();
            LocalData.PaintedDogs.Refresh();
        }

        public async Task ResetRace()
        {
            simulator.TakeDogsToStart();

            await InvokeAsync(StateHasChanged);
        }

        public async Task RunRaceStep(int dogNumber)
        {
            simulator.SimulateStep(dogNumber % 4);
            curPosDog0 = LocalData.hounds[0].getCurrentPosition().ToString();
            curPosDog1 = LocalData.hounds[1].getCurrentPosition().ToString();
            curPosDog2 = LocalData.hounds[2].getCurrentPosition().ToString();
            curPosDog3 = LocalData.hounds[3].getCurrentPosition().ToString();

            LocalData.PaintedDogs.Refresh();
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

        public void PlaceBet()
        {
            Debug.Print("Todo");
        }
    }   
}