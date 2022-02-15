namespace RaceGameUI_BlazorPractice.Web.Services
{
    public interface IRaceTrackService
    {
        Task SimulateRace();
        Task ResetRace();
        Task Payout();
    }
}
