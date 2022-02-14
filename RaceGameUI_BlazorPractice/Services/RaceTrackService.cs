using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class RaceTrackService: IRaceTrackService
    {
        public static int minInvestment = 5;
        public static int maxInvestment = 15;
        public static int trackLength = 100;
        public int raceNumber = 0;
        public bool raceEnded = false;

        private readonly IGreyHoundService _greyHounds;

        public RaceTrackService(IGreyHoundService GreyHoundService)
        {
            _greyHounds = GreyHoundService;
        }

        public async void SimulateRace()
        {
            _greyHounds.TakeDogsToStart();
            int dogNumber = 0;
            Debug.Print("Now running simulation #" + raceNumber);

            while (!raceEnded)
            {
                await _greyHounds.RunAsync(dogNumber);

                Thread.Sleep(5);
                dogNumber++;
                raceEnded = _greyHounds.AreDogsFinished();
            }

            raceNumber++;

        }

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

    }
}
