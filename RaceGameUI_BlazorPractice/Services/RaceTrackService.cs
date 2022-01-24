namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class RaceTrackService
    {
        public static int minInvestment = 50;
        public static int maxInvestment = 500000;
        // Start Race
        //    int dogNumber = 0;

        //    Debug.Print("Now running simulation #" + LocalData.RaceNumber);
        //        while (!simulator.RaceEnded())
        //        {
        //            await RunRaceStep(dogNumber);

        //    Thread.Sleep(5);
        //            dogNumber++;
        //        }

        //int winningDogNumber = (dogNumber - 1) % LocalData.AmountGreyHounds + 1;

    //public void TakeDogsToStart()
    //{
    //    this.houndsFinished = 0;

    //    foreach (var hound in LocalData.hounds)
    //    {
    //        hound.ResetPosition();
    //        hound.finished = false;
    //        hound.hideMedal1 = true;
    //        hound.hideMedal2 = true;
    //        hound.hideMedal3 = true;
    //    }

    //}

    //public void SimulateStep(int dogNumber)
    //{
    //    GreyHoundViewModel hound = LocalData.hounds[dogNumber];

    //    if (!hound.finished)
    //    {
    //        hound.Run();

    //        if (hound.GetCurrentPosition() >= _trackLength)
    //        {
    //            hound.finished = true;

    //            if (this.houndsFinished == 0)
    //            {
    //                hound.hideMedal1 = false;
    //                this.houndsFinished++;
    //            }
    //            else if (this.houndsFinished == 1)
    //            {
    //                hound.hideMedal2 = false;
    //                this.houndsFinished++;
    //            }
    //            else if (this.houndsFinished == 2)
    //            {
    //                hound.hideMedal3 = false;
    //                this.houndsFinished++;
    //            }

    //        }
    //    }
    //}

    //public bool RaceEnded()
    //{
    //    foreach (var hound in LocalData.hounds)
    //    {
    //        if (!hound.finished)
    //        {
    //            return false;
    //        }
    //    }

    //    return true;
    //}
}
}
