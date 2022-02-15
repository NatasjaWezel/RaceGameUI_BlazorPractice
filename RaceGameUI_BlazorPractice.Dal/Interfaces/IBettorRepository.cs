using RaceGameUI_BlazorPractice.Model;

namespace RaceGameUI_BlazorPractice.Dal
{
    public interface IBettorRepository
    {
        List<BettorEntityModel> GetBettors(string FileName);
    }
}
