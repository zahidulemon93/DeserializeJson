using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace DeserializeJson
{
    //public class Stats
    //{
    //    public string Label { get; set; }
    //    public int Value { get; set; }
    //}

    //public class MyModel
    //{
    //    public int Id { get; set; }
    //    public int Grade { get; set; }
    //    public string Statistics { get; set; }
    //}


    public class Stats
    {
        public int AvatarAdd { get; set; }
        public int TotalPlays { get; set; }
        public int GameTotalPlaysSpellMemWords { get; set; }
        public int BookTotalReadsCount { get; set; }
        public int GameTotalPlaysCount { get; set; }
        public int CharacterTotalPlaysL { get; set; }
        public int CharacterTotalPlaysE { get; set; }
        public int TotalPlaysPick_Vocab { get; set; }
        public int CharacterTotalPlaysR { get; set; }
    }
    public class MyModel
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public Stats Statistics { get; set; }
    }
    class Program
    {
        static Collection<MyModel> LoadData(string data)
        {
            var retval = JsonConvert.DeserializeObject<Collection<MyModel>>(data);
            return retval;
        }

        static void Main(string[] args)
        {
            try
            {
                string s = File.ReadAllText(@"test-data.json");
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };
                Collection<MyModel> mockData = Program.LoadData(s);
                System.Console.WriteLine("#/items= " + mockData.Count);
                foreach (MyModel item in mockData)
                {
                    System.Console.WriteLine("  id= {0}, Grade={1}, Statistics={2}", item.Id, item.Grade, item.Statistics.ToString());
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("ERROR:", ex);
            }
        }
    }
}
