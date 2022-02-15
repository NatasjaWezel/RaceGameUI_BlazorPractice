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
            
            // skip header
            reader.ReadLine();
            
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(';');

                Bettors.Add(new BettorEntityModel() { Name = values[1],
                                                      StartingCash = Int32.Parse(values[2]),
                                                      CurrentCash = Int32.Parse(values[3])});
            }

            return Bettors;
        }
    }
}
