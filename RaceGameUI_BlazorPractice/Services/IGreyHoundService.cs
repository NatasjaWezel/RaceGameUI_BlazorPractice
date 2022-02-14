using Microsoft.AspNetCore.Components;
using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IGreyHoundService
    {
        Task<List<GreyHoundViewModel>> GetGreyHoundsAsync();
        Task<GreyHoundViewModel> GetGreyHound(int id);
        string GetGreyHoundName(int id);
        public event Action? OnDogStep;

        Task RunAsync(int dogNumber);

        Task<bool> AreDogsFinished();
        Task TakeDogsToStart();
    }
}
