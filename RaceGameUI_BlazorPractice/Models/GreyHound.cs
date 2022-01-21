namespace RaceGameUI_BlazorPractice.Web.Models
{
    public class GreyHound
    {
        public bool hideMedal1 = true;
        public bool hideMedal2 = true;
        public bool hideMedal3 = true;
        
        public int GetPercentage()
        {
            int percentage = (int)Math.Ceiling((double)_currentPosition / 100 * 80);
            return percentage;
        }
    }
}
