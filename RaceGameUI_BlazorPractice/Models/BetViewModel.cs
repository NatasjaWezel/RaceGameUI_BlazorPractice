namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class BetViewModel
    {
        public int Amount { get; }
        public int DogId { get; }

        public BetViewModel(int dognumber, int amount)
        {
            DogId = dognumber;
            Amount = amount;
        }

        public int PayOut(int WinningDogNumber)
        {
            if (WinningDogNumber == DogId)
            {
                return Amount;
            }

            return -Amount;
        }
    }
}
