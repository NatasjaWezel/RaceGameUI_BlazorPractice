using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IGreyHoundService
    {
        // event that blazor component can subscribe to to refresh
        public event Action? OnDogStep;

        Task<List<GreyHoundViewModel>> GetGreyHoundsAsync();
        Task<GreyHoundViewModel> GetGreyHound(int id);
        Task RunAsync(int dogNumber);
        Task<bool> AreDogsFinished();
        Task TakeDogsToStart();
        string GetGreyHoundName(int id);
    }
}
