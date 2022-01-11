namespace RaceGameUI_BlazorPractice
{
    public class GreyHound
    {
        private int DogNumber;
        private int InitialPosition = 0;
        private int CurrentPosition;
        private List<int> positions = new List<int>();

        // an instance of random
        public Random Randomizer;

        public GreyHound(int DogNumer, Random Randomizer)
        {
            this.DogNumber = DogNumer;
            this.Randomizer = Randomizer;
            
            CurrentPosition = InitialPosition;
            positions.Append(InitialPosition);
        }

        
        public void Run()
        {
            // run between 1 and 4 spaces at random
            CurrentPosition += Randomizer.Next(1, 5);
            positions.Append(CurrentPosition);
        }

        public void ResetPosition()
        {
            CurrentPosition = InitialPosition;
        }

        public int getCurrentPosition()
        {
            return CurrentPosition;
        }

        public List<int> getPositions()
        {
            return positions;
        }
        
    }
}
