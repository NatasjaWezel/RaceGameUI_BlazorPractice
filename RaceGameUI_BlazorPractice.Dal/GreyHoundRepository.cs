using RaceGameUI_BlazorPractice.Model;

namespace RaceGameUI_BlazorPractice.Dal
{
    public class GreyHoundRepository: IGreyHoundRepository
    {
        public List<GreyHoundEntityModel> GetGreyHounds(string FileName)
        {
            List<GreyHoundEntityModel> GreyHounds = new();

            var reader = new StreamReader(FileName);
            var headerLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

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
