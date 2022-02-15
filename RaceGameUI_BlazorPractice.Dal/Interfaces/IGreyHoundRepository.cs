using RaceGameUI_BlazorPractice.Model;

namespace RaceGameUI_BlazorPractice.Dal
{
    public interface IGreyHoundRepository
    {
        List<GreyHoundEntityModel> GetGreyHounds(string FileName);
    }
}
