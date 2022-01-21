using RaceGameUI_BlazorPractice.Web.Models;

namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IGreyHoundService
    {
        Task<List<GreyHoundViewModel>> GetGreyHoundsAsync();

        Task RunAsync();
    }
}
