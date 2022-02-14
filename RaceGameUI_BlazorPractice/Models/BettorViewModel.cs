using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class BettorViewModel
    {
        public string Name { get; set; }
        public int StartingCash { get; set; }
        public int CurrentCash { get; set; }

        public BetViewModel? MyBet = null;
    }
}
