using System.Diagnostics;

namespace RaceGameUI_BlazorPractice
{
    public class SimulateRace
    {
        private readonly int _trackLength = 100;
        private bool finished = false;

        public void CalculateBetResult(int winningDogNumber)
        {
            foreach (var bettor in LocalData.bettors)
            {
                bettor.Value.Collect(winningDogNumber);
                bettor.Value.ClearBet();
            }
        }

        public void TakeDogsToStart()
        {
            foreach (var hound in LocalData.hounds)
            {
                hound.ResetPosition();
                this.finished = false;
            }

        }

        public void SimulateStep(int dogNumber)
        {
            LocalData.hounds[dogNumber].Run();

            if (LocalData.hounds[dogNumber].GetCurrentPosition() >= _trackLength)
            {
                this.finished = true;
            }
        }

        public bool RaceEnded()
        {
            return finished;
        }

        public int GetHoundPosition(int dognumber)
        {
            return LocalData.hounds[dognumber].GetCurrentPosition();
        }
    }
}
