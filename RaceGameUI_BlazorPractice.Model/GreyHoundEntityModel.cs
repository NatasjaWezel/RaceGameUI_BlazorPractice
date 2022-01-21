namespace RaceGameUI_BlazorPractice.Model
{
    public class GreyHoundEntityModel
    {
        public string Name { get; set; }

        public readonly Random _randomizer;

        public int Id { get; set; }
 
        public int InitialPosition = 0;
        public int CurrentPosition = 0;

        public bool finished = false;
    }
}
