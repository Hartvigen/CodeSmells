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

        static public void run(bool typeChecking)
        {
            List<StreamerBase> streamers = createData(typeChecking);

        }
        
        static public List<StreamerBase> createData(bool typeChecking)
        {
            List<StreamerBase> streamers;

            using (var reader = new StreamReader("publish/twitch.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                streamers = csv.GetRecords<StreamerBase>().ToList();
            }
            

            return streamers;
        }
    }
    
    public abstract class StreamerBase
    {
        public abstract int GetType();
        public abstract string GetTypeString();
        
        [Name("Channel")]
        public string Channel { get; set; }
        [Name("Watch time(Minutes)")]
        public UInt64 WatchTime { get; set; }
        [Name("Peak viewers")]
        public string PeakViewers { get; set; }
        [Name("Average viewers")]
        public string AvgViewers { get; set; }
        [Name("Followers")]
        public UInt32 Followers { get; set; }
        [Name("Followers gained")]
        public int FollowersGained { get; set; }
        [Name("Views gained")]
        public int ViewsGained { get; set; }
        [Name("Partnered")]
        public bool Partnered { get; set; }
        [Name("Mature")]
        public bool Mature { get; set; }
        [Name("Language")]
        public string Language { get; set; }

    }
    
    public class Streamer : StreamerBase
    {
        public override int GetType()
        {
            throw new NotImplementedException();
        }

        public override string GetTypeString()
        {
            throw new NotImplementedException();
        }
    }
    public class PartneredStreamer : StreamerBase
    {
        public PartneredStreamer(StreamerBase streamer)
        {
            
        }

        public override int GetType()
        {
            throw new NotImplementedException();
        }

        public override string GetTypeString()
        {
            throw new NotImplementedException();
        }
    }

    public class UnpartneredStreamer : StreamerBase
    {
        public UnpartneredStreamer(StreamerBase streamer)
        {
            
        }
        
        public override int GetType()
        {
            throw new NotImplementedException();
        }

        public override string GetTypeString()
        {
            throw new NotImplementedException();
        }
    }
}