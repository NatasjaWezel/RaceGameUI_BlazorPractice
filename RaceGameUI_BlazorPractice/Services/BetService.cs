namespace RaceGameUI_BlazorPractice.Web.Services
{
    public class BetService: IBetService
    {
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

    }
}
