using RaceGameUI_BlazorPractice.Model;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice.Dal
{
    public class BettorRepository: IBettorRepository
    {
        public List<BettorEntityModel> GetBettors(String FileName)
        {
            List<BettorEntityModel> Bettors = new();

            var reader = new StreamReader(FileName);
            var headerLine = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                Debug.Print(line);
                var values = line.Split(';');

                Bettors.Add(new BettorEntityModel() { Name = values[1],
                                                      StartingCash = Int32.Parse(values[2]),
                                                      CurrentCash = Int32.Parse(values[3])});
            }

            return Bettors;
        }
    }
}
