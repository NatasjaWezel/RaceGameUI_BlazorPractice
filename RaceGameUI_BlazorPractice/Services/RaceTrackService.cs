using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class RaceTrackService: IRaceTrackService
    {
        public static int minInvestment = 5;
        public static int maxInvestment = 15;
        public static int trackLength = 100;
        public int noDogsFinished = 0;
        public int raceNumber = 0;
        public bool raceEnded = false;

        private readonly IGreyHoundService _greyHounds;
        private readonly IBettorService _bettors;

        public RaceTrackService(IGreyHoundService GreyHoundService, IBettorService bettors)
        {
            _greyHounds = GreyHoundService;
            _bettors = bettors;
        }

        public async Task SimulateRace()
        {
            await ResetRace();
            int dogNumber = 0;
            Debug.Print($"Simulating race #{raceNumber}");

            while (!raceEnded)
            {
                await _greyHounds.RunAsync(dogNumber);
                await Task.Delay(5);

                dogNumber++;
                raceEnded = await _greyHounds.AreDogsFinished();
            }
            await Payout();
            raceNumber++;
        }

        public async Task Payout()
        {
            await _bettors.CollectPayout();
        }

        public async Task ResetRace()
        {
            raceEnded = false;
            await _greyHounds.TakeDogsToStart();
        }
    }
}
