namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class GreyHound
    {
        private readonly int _id;
        private readonly Random _randomizer;

        private readonly int _initialPosition = 0;
        private int _currentPosition;

        public bool hideMedal1 = true;
        public bool hideMedal2 = true;
        public bool hideMedal3 = true;
        public bool finished = false;

        public GreyHound(int dogNumber, Random randomizer)
        {
            _id = dogNumber;
            _randomizer = randomizer;

            _currentPosition = _initialPosition;
        }

        public int GetId()
        {
            return _id;
        }

        public void Run()
        {
            // run between 1 and 4 spaces at random
            int addToPos = _randomizer.Next(1, 5);

            // make sure hound doesn't run further than the finish
            if (_currentPosition + addToPos >= LocalData.RaceTrackLength)
            {
                _currentPosition = LocalData.RaceTrackLength;
            }
            else
            {
                _currentPosition += addToPos;
            }
        }

        public void ResetPosition()
        {
            _currentPosition = _initialPosition;
        }

        public int GetPercentage()
        {
            int percentage = (int)Math.Ceiling((double)_currentPosition / 100 * 80);
            return percentage;
        }

        public int GetCurrentPosition()
        {
            return _currentPosition;
        }
    }
}
