namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class GreyHoundViewModel
    {
        public string? Name { get; set; }

        public int Id { get; set; }

        public int initialPosition;
        public int currentPosition;

        public bool finished;
        public int? finishPosition;

        public bool hideMedal1 = true;
        public bool hideMedal2 = true;
        public bool hideMedal3 = true;
        
        public int GetPercentage()
        {
            int percentage = (int)Math.Ceiling((double) currentPosition / 100 * 80);
            return percentage;
        }
    }
}
