namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class Bet
    {
        private int _amount;
        private int _dogNumber;
        private BettorViewModel _bettor;
        private bool _hasPreviousBet;

        public Bet(BettorViewModel Bettor)
        {
            _hasPreviousBet = false;
            _bettor = Bettor;
            _amount = 0;
        }

        public Bet(BettorViewModel Bettor, int amount, int dognumber)
        {
            _amount = amount;
            _dogNumber = dognumber;
            _bettor = Bettor;
        }

        //public string GetDescription()
        //{
        //    if (_amount == 0 && _hasPreviousBet)
        //    {
        //        return _bettor.GetName() + " can't place bets anymore.";
        //    }
        //    else if (_amount == 0)
        //    {
        //        return _bettor.GetName() + " hasn't placed a bet yet.";
        //    }
        //    _hasPreviousBet = true;
        //    return _bettor.GetName() + " betted " + _amount.ToString() + " on dog number: " + _dogNumber.ToString();
        //}

        public void Clear()
        {
            _amount = 0;
            _dogNumber = 0;
        }

        public string GetAmount()
        {
            if (_amount == 0)
            {
                return "-";
            }
            return _amount.ToString();
        }

        public string GetDogNumber()
        {
            if (_dogNumber == 0)
            {
                return "-";
            }
            return _dogNumber.ToString();
        }

        public int PayOut(int WinningDogNumber)
        {
            if (WinningDogNumber == _dogNumber)
            {
                return _amount;
            }

            return -_amount;
        }
    }
}
