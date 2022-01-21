namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class GreyHoundViewModel
    {
        public string Name { get; set; }

        public readonly Random _randomizer;

        public int Id { get; set; }

        public int InitialPosition = 0;
        public int CurrentPosition = 0;

        public bool finished = false;


        public bool hideMedal1 = true;
        public bool hideMedal2 = true;
        public bool hideMedal3 = true;
        
        public int GetPercentage()
        {
            int percentage = (int)Math.Ceiling((double) CurrentPosition / 100 * 80);
            return percentage;
        }
    }
}
