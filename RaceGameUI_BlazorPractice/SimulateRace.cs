using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web
{
    public class SimulateRace
    {
        private readonly int _trackLength = 100;
        private int houndsFinished = 0;

        public void TakeDogsToStart()
        {
            this.houndsFinished = 0;

            foreach (var hound in LocalData.hounds)
            {
                hound.ResetPosition();
                hound.finished = false;
                hound.hideMedal1 = true;
                hound.hideMedal2 = true;
                hound.hideMedal3 = true;
            }

        }

        public void SimulateStep(int dogNumber)
        {
            GreyHound hound = LocalData.hounds[dogNumber];

            if (!hound.finished)
            {
                hound.Run();

                if (hound.GetCurrentPosition() >= _trackLength)
                {
                    hound.finished = true;

                    if (this.houndsFinished == 0)
                    {
                        hound.hideMedal1 = false;
                        this.houndsFinished++;
                    } else if (this.houndsFinished == 1)
                    {
                        hound.hideMedal2 = false;
                        this.houndsFinished++;
                    } else if (this.houndsFinished == 2)
                    {
                        hound.hideMedal3 = false;
                        this.houndsFinished++;
                    }
                    
                }
            }
        }

        public bool RaceEnded()
        {
            foreach (var hound in LocalData.hounds)
            {
                if (!hound.finished)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHoundPosition(int dognumber)
        {
            return LocalData.hounds[dognumber].GetCurrentPosition();
        }
    }
}
