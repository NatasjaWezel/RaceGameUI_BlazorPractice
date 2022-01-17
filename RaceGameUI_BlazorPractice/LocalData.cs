namespace RaceGameUI_BlazorPractice
{
    public class LocalData
    {
        public static int RaceTrackLength = 100;
        public static int MinimumBet = 5;
        public static int RaceNumber = 0;

        // to bind html elements with
        public static string BettorName = "";
        public static int Amount = MinimumBet;
        public static int DogNumber = 0;

        public static string NewPlayerName = "";
        public static int NewPlayerStartCash = MinimumBet;

        private static Random random = new Random();

        public static List<GreyHound>? hounds = new() {
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

        public static Dictionary<string, Bettor> bettors = new() {
                        ["Joe"] = new Bettor("Joe", 50),
                        ["Bodei"] = new Bettor("Bodei", 100),
                        ["Bob"] = new Bettor("Bob", 75),
                        ["Al"] = new Bettor("Al", 45),
                        ["Romy"] = new Bettor("Romy", 10)
        };

        public static List<(DateTime, String)> BettingHistory = new();
    }
}
