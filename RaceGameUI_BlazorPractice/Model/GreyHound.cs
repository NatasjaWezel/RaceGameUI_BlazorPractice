using System.Diagnostics;

namespace RaceGameUI_BlazorPractice
{
    public class GreyHound
    {
        private readonly int _id;
        private readonly Random _randomizer;

        private readonly int _initialPosition = 0;
        private int _currentPosition;

        public GreyHound(int dogNumber, Random randomizer)
        {
            _id = dogNumber;
            this._randomizer = randomizer;
            
            _currentPosition = _initialPosition;
        }

        public int GetId()
        {
            return _id;
        }

        public void Run()
        {
            Debug.Print("running");
            // run between 1 and 4 spaces at random
            _currentPosition += _randomizer.Next(1, 5);
        }

        public void ResetPosition()
        {
            _currentPosition = _initialPosition;
        }

        public int GetPercentage()
        {
            double resizePercentage = (double) _currentPosition / 100 * 80;
            int percentage = (int) Math.Ceiling(resizePercentage);
            Debug.Print(_currentPosition.ToString() + "  " + resizePercentage.ToString() + "  " + percentage.ToString());
            return percentage;
        }

        public int GetCurrentPosition()
        {
            return _currentPosition;
        }        
    }
}
