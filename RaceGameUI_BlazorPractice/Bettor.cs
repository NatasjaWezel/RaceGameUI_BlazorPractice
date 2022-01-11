using System.Diagnostics;

namespace RaceGameUI_BlazorPractice
{
    public class Bettor
    {
        private string _name;
        private Bet _myBet;
        private int _cash;
        private int _startCash;

        public Bettor(string name, int cash)
        {
            _name = name;
            _cash = cash;
            _startCash = cash;
            _myBet = new Bet(this);
        }

        public string GetName()
        {
            return _name;
        }

        public int GetStartCash()
        {
            return _startCash;
        }
        public int GetCurrentCash()
        {
            return _cash;
        }

        public string getLabel()
        {
            return _name + " has " + _cash + " bucks";
        }

        public void ClearBet()
        {
            _myBet.Clear();
        }

        public bool PlaceBet(int Amount, int DogNumber)
        {
            if (Amount <= _cash)
            {
                _myBet = new Bet(this, Amount, DogNumber);
                Debug.Print(_myBet.GetDescription());
                return true;
            }

            // all cash is gone
            Debug.Print(_name + " cash is gone");
            _myBet.Clear();
            return false;
        }

        public bool PlaceRandomBet()
        {
            Random rand = new Random();
            if (this.GetCurrentCash() >= LocalData.MinimumBet)
            {
                this.PlaceBet(rand.Next(LocalData.MinimumBet, this.GetCurrentCash()), rand.Next(1, 5));
                return true;
            }

            Debug.Print(_name + " cash is gone");
            _myBet.Clear();
            return false;
        }

        public void Collect(int WinnerDogNumber)
        {
            _cash += _myBet.PayOut(WinnerDogNumber);
        }

        public Bet GetBet()
        {
            return _myBet;
        }
    }
}
