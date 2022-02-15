using RaceGameUI_BlazorPractice.Model;

namespace RaceGameUI_BlazorPractice.Dal
{
    public class GreyHoundRepository: IGreyHoundRepository
    {
        public List<GreyHoundEntityModel> GetGreyHounds(string FileName)
        {
            List<GreyHoundEntityModel> GreyHounds = new();

            var reader = new StreamReader(FileName);
            
            // skip header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(';');

                GreyHounds.Add(new GreyHoundEntityModel()
                {
                    Id = Int32.Parse(values[0]),
                    Name = values[1]
                });
            }

            return GreyHounds;
        }
    }
}
