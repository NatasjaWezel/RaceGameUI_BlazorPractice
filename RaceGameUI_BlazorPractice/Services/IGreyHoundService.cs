using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IGreyHoundService
    {
        Task<List<GreyHoundViewModel>> GetGreyHoundsAsync();
        List<GreyHoundViewModel> GetGreyHounds();

        Task RunAsync(int dogNumber);

        bool AreDogsFinished();
        void TakeDogsToStart();
    }
}
