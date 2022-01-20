using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web
{
    public class LocalData
    {
        public static int RaceTrackLength = 100;
        public static int MinimumBet = 5;
        public static int MaximumBet = 100;
        public static int RaceNumber = 0;

        // to bind html elements with
        public static string BettorName = "";
        public static int Amount = MinimumBet;
        public static int DogNumber = 0;

        public static string NewPlayerName = "";
        public static int NewPlayerStartCash = MinimumBet;

        private static Random random = new Random();

        public static List<GreyHound> hounds = new()
        {
            new GreyHound(0, random),
            new GreyHound(1, random),
            new GreyHound(2, random),
            new GreyHound(3, random),
            new GreyHound(4, random),
            new GreyHound(5, random),
            new GreyHound(6, random),
            new GreyHound(7, random),
            new GreyHound(8, random)
        };
        public static readonly int AmountGreyHounds = hounds.Count;
    }
}
