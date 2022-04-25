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

        //Smells will be run if corresponding boolean parameter is true, otherwise a non-smelly version is run
        static public void run(bool typeChecking, bool inline, bool repeatCond)
        {
            List<StreamerBase> streamers = createData();
            
            //Smells will be called one-by-one depending on parameter settings
            //
            //Type checking smell
            if (typeChecking)
            {
                foreach (var streamer in streamers)
                {
                    TypeCheckingGood typeChecker = new TypeCheckingGood(streamer);
                    typeChecker.getType();
                }
            }

            else
            {
                foreach (var streamer in streamers)
                {
                    TypeCheckingBad typeChecker = new TypeCheckingBad(streamer);
                    typeChecker.getType();
                }
            }
            
            //In-line smell
            if (inline)
            {
                foreach (var streamer in streamers)
                {
                    streamer.Followers += 2;
                    streamer.Followers = streamer.Followers * 2;
                    streamer.Followers -= 4;
                    streamer.Followers = streamer.Followers / 2;
                    streamer.Followers += 1;

                }
            }

            else
            {
                foreach (var streamer in streamers)
                {
                    streamer.Followers = inLineCalc(streamer.Followers);

                }
            }
            
            //Repeated Conditionals
            if (repeatCond)
            {
                foreach (var streamer in streamers)
                {
                    if (streamer.Language == "Spanish")
                    {
                        streamer.Mature = true;
                    }
                    
                    if (streamer.Language == "Spanish")
                    {
                        streamer.Followers -= 500;
                    }
                }
            }

            else
            {
                foreach (var streamer in streamers)
                {
                    if (streamer.Language == "Spanish")
                    {
                        streamer.Mature = true;
                        streamer.Followers -= 500;
                    }
                }
            }

        }

        static private uint inLineCalc(uint followers)
        {
            followers += 2;
            followers = followers * 2;
            followers -= 4;
            followers = followers / 2;
            followers += 1;

            return followers;
        }
        
        static private List<StreamerBase> createData()
        {
            List<Streamer> streamersIni;
            List<StreamerBase> streamers = new List<StreamerBase>();

            using (var reader = new StreamReader("publish/twitch.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                streamersIni = csv.GetRecords<Streamer>().ToList();
            }

            foreach (var streamer  in streamersIni)
            {
                if (streamer.Partnered)
                    streamers.Add(new PartneredStreamer(streamer));
                else 
                    streamers.Add(new UnpartneredStreamer(streamer));
            }

            
            
            return streamers;
        }
    }

    public class Streamer : StreamerBase
    {
        public override int GetTypeField()
        {
            if (Partnered) return 1;
            else return 0;
        }

        public override string GetTypeString()
        {
            if (Partnered) return "Partnered";
            else return "Unpartnered";
        }
    }
    
    public abstract class StreamerBase
    {
        public int UNPARTNERED = 0;
        public int PARTNERED = 1;
        public abstract int GetTypeField();
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


    public abstract class TypeCheckingBase
    {
        public abstract string getType();
    }

    public class TypeCheckingGood : TypeCheckingBase
    {
        private StreamerBase state;
        public override string getType()
        {
            return state.GetTypeString();
        }

        public TypeCheckingGood(StreamerBase state)
        {
            this.state = state;
        }
    }

    public class TypeCheckingBad : TypeCheckingBase
    {
        private StreamerBase obj;
        private bool UNPARTNERED = false;
        private bool PARTNERED = true;
        public override string getType()
        {
            if (this.obj.GetType() == typeof(PartneredStreamer)) return "Partnered";
            else if (this.obj.GetType() == typeof(UnpartneredStreamer)) return "Unpartnered";
            else return "Error";
        }

        public TypeCheckingBad(StreamerBase type)
        {
            this.obj = type;
        }
    }
    public class PartneredStreamer : StreamerBase
    {
        public PartneredStreamer(StreamerBase streamer)
        {
            Channel = streamer.Channel;
            WatchTime = streamer.WatchTime;
            PeakViewers = streamer.PeakViewers;
            AvgViewers = streamer.AvgViewers;
            Followers = streamer.Followers;
            FollowersGained = streamer.FollowersGained;
            ViewsGained = streamer.FollowersGained;
            Mature = streamer.Mature;
            Language = streamer.Language;

        }
        
        public override int GetTypeField()
        {
            return this.PARTNERED;
        }

        public override string GetTypeString()
        {
            return "Partnered";
        }
    }

    public class UnpartneredStreamer : StreamerBase
    {
        public UnpartneredStreamer(StreamerBase streamer)
        {
            Channel = streamer.Channel;
            WatchTime = streamer.WatchTime;
            PeakViewers = streamer.PeakViewers;
            AvgViewers = streamer.AvgViewers;
            Followers = streamer.Followers;
            FollowersGained = streamer.FollowersGained;
            ViewsGained = streamer.FollowersGained;
            Mature = streamer.Mature;
            Language = streamer.Language;
        }


        public override int GetTypeField()
        {
            return this.UNPARTNERED;
        }

        public override string GetTypeString()
        {
            return "Unpartnered";
        }
    }
}