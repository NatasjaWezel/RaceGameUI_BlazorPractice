namespace RaceGameUI_BlazorPractice
{
    public class LocalData
    {
        public static RenderTrackComponent? PaintedDogs = null;

        public static int RaceTrackLength = 100;
        public static int MinimumBet = 5;
        public static int RaceNumber = 0;

        public static List<GreyHound>? hounds = null;

        public static Dictionary<string, Bettor> bettors = new() {
                        ["Joe"] = new Bettor("Joe", 50),
                        ["Bodei"] = new Bettor("Bodei", 100),
                        ["Bob"] = new Bettor("Bob", 75),
                        ["Al"] = new Bettor("Al", 45),
                        ["Romy"] = new Bettor("Romy", 10)
        };
    }
}
