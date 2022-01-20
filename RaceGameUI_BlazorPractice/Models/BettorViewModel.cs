using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class BettorViewModel
    {
        public string Name { get; set; }
        public int StartingCash { get; set; }
        public int CurrentCash { get; set; }

        public Bet MyBet;
        public BettorViewModel()
        {
            MyBet = new Bet(this);
        }

    //    public string getLabel()
    //    {
    //        return Name + " has " + CurrentCash + " bucks";
    //    }

    //    public void ClearBet()
    //    {
    //        MyBet.Clear();
    //    }

    //    public void PlaceBet(int Amount, int DogNumber)
    //    {
    //        if (Amount <= CurrentCash)
    //        {
    //            MyBet = new Bet(this, Amount, DogNumber);
    //        }

    //        Debug.Print(MyBet.GetDescription());
    //    }

    //    public bool PlaceRandomBet()
    //    {
    //        Random rand = new Random();
    //        if (CurrentCash >= LocalData.MinimumBet)
    //        {
    //            PlaceBet(rand.Next(LocalData.MinimumBet, CurrentCash), rand.Next(1, LocalData.AmountGreyHounds));
    //            return true;
    //        }

    //        Debug.Print(Name + " cash is gone");
    //        MyBet.Clear();
    //        return false;
    //    }

    //    public void Collect(int WinnerDogNumber)
    //    {
    //        CurrentCash += MyBet.PayOut(WinnerDogNumber);
    //    }

    //    public Bet GetBet()
    //    {
    //        return MyBet;
    //    }
    }
}
