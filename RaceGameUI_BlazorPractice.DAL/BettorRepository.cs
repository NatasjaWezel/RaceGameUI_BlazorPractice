using RaceGameUI_BlazorPractice.Model;

namespace RaceGameUI_BlazorPractice.Dal
{
    public class BettorRepository: IBettorRepository
    {
        public List<BettorEntityModel> GetBettors(String FileName)
        {
            List<BettorEntityModel> Bettors = new List<BettorEntityModel>();

            var reader = new StreamReader(FileName);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                Bettors.Add(new BettorEntityModel() { Name = values[0],
                                                      StartingCash = Int32.Parse(values[1])});
            }

            return Bettors;
        }
    }
}
