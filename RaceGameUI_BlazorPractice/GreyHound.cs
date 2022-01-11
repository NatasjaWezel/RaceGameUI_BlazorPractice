namespace RaceGameUI_BlazorPractice
{
    public class GreyHound
    {
        private readonly int _id;
        private readonly int _initialPosition = 0;
        private int CurrentPosition;

        // an instance of random
        public Random Randomizer;

        public GreyHound(int DogNumer, Random Randomizer)
        {
            _id = DogNumer;
            this.Randomizer = Randomizer;
            
            CurrentPosition = _initialPosition;
        }

        public int GetId()
        {
            return _id;
        }

        public void Run()
        {
            // run between 1 and 4 spaces at random
            CurrentPosition += Randomizer.Next(1, 5);
        }

        public void ResetPosition()
        {
            CurrentPosition = _initialPosition;
        }

        public int getCurrentPosition()
        {
            return CurrentPosition;
        }        
    }
}
