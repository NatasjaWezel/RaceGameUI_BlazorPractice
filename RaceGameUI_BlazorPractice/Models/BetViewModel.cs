namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class BetViewModel
    {
        private int _amount;
        private int _dogNumber;

        public BetViewModel()
        {
            _amount = 0;
            _dogNumber = -1;
        }

        public BetViewModel(int amount, int dognumber)
        {
            _amount = amount;
            _dogNumber = dognumber;
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
            _dogNumber = -1;
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
            if (_dogNumber == -1)
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
