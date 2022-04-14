using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace allSmells
{
    public class SuperSmell
    {

        static public void run()
        {
            List<SuperSmell> streamers = createData();

            foreach (var streamer in streamers)
            {
                Console.WriteLine(streamer.Channel);
            }
        }
        static public List<SuperSmell> createData()
        {
            List<SuperSmell> streamers;

            using (var reader = new StreamReader(@".\twitch.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                streamers = csv.GetRecords<SuperSmell>().ToList();
            }

            return streamers;
        }

        [Name("Channel")]
        public string Channel { get; set; }
        [Name("Watch time(Minutes)")]
        public DateTime WatchTime { get; set; }
        [Name("Peak viewers")]
        public string PeakViewers { get; set; }
        [Name("Average viewers")]
        public string AvgViewers { get; set; }
        [Name("Followers")]
        public int Followers { get; set; }
        [Name("Followers gained")]
        public int FollowersGained { get; set; }
        [Name("Views gained")]
        public int ViewsGained { get; set; }
        [Name("Partnered")]
        public int Partnered { get; set; }
        [Name("Mature")]
        public int Mature { get; set; }
        [Name("Language")]
        public int Language { get; set; }
        
        
        
        
    }
}