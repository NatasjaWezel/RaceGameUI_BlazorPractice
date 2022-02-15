namespace RaceGameUI_BlazorPractice.Model
{
    public class GreyHoundEntityModel
    {
        public string Name { get; set; } = "";

        public readonly Random? _randomizer;

        public int Id { get; set; }
 
        public int initialPosition = 0;
        public int currentPosition = 0;

        public bool finished = false;
        
        public int? finishPosition = null;
    }
}
