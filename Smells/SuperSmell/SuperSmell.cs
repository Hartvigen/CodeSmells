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
        static public void run(bool typeChecking, bool inline, bool repeatCond, bool deadLocalStore, bool duplicateCode, bool shortCircuit, bool featureEnvy, bool paramByValue, bool selfAssignment, bool redundantStorage)
        {
            List<StreamerBase> streamers = createData();

            //Smells will be called sequentially depending on parameter settings
            foreach (var streamer in streamers)
            {
                //Type checking smell
                if(typeChecking)
                {
                    TypeCheckingGood typeChecker = new TypeCheckingGood(streamer);
                    typeChecker.getType();
                }

                else
                {
                    TypeCheckingBad typeChecker = new TypeCheckingBad(streamer);
                    typeChecker.getType();
                }

                //In-line smell
                if (inline)
                {
                    streamer.Followers = inLineCalc(streamer.Followers);
                }

                else
                {
                    streamer.Followers += 2;
                    streamer.Followers = streamer.Followers * 2;
                    streamer.Followers -= 4;
                    streamer.Followers = streamer.Followers / 2;
                    streamer.Followers += 1;
                }

                //Repeated Conditionals
                if (repeatCond)
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

                else
                {
                    if (streamer.Language == "Spanish")
                    {
                        streamer.Mature = true;
                        streamer.Followers -= 500;
                    }
                }

                //Dead Local Store
                if (deadLocalStore)
                {
                    double pi = 3.14;
                    double notPi = 4.13;
                    int cousinsAgeInMonths = 146;
                    string niceGreeting = "Hellow World";

                    streamer.radiusOfFollowers = pi * Math.Pow(2, streamer.Followers);

                }

                else
                {
                    double pi = 3.14;

                    streamer.radiusOfFollowers = pi * Math.Pow(2, streamer.Followers);
                }

                //Duplicate Code
                List<int> list_a = new List<int>() {1, 3, 5, 7, 9};
                List<int> list_b = new List<int>() {2, 4, 6, 8, 10};
                
                if (duplicateCode)
                {
                    int sum_a = 0;
                    int sum_b = 0;

                    for (int x = 0; x < 4; x++)
                    {
                        sum_a += list_a[x];
                    }

                    int average_a = sum_a / 4;
            
                    for (int x = 0; x < 4; x++)
                    {
                        sum_b += list_b[x];
                    }
                }

                else
                {
                    int sum_a = 0;
                    int sum_b = 0;
            
                    for (int x = 0; x < 4; x++)
                    {
                        sum_a += list_a[x];
                        sum_b += list_b[x];
                    }

                    int average_a = sum_a / 4;
                    int average_b = sum_b / 4;
                }
                
                
                //Short circuit
                if (shortCircuit)
                {
                    if(streamer.PeakViewers > streamer.AvgViewers | streamer.Followers > streamer.FollowersGained) 
                        streamer.AvgViewers +=1;

                    if (streamer.AvgViewers > streamer.PeakViewers & streamer.Followers > 0)
                        streamer.Followers += 1;

                }

                else
                {
                    if(streamer.PeakViewers > streamer.AvgViewers || streamer.Followers > streamer.FollowersGained) 
                        streamer.AvgViewers +=1;

                    if (streamer.AvgViewers > streamer.PeakViewers && streamer.Followers > 0)
                        streamer.Followers += 1;
                }

                followerInfoHolder holder = new followerInfoHolder(streamer);
                int totalFollowers;
                int val;
                
                //Feature Envy
                if (featureEnvy)
                {
                    totalFollowers = (int)holder.Followers + holder.FollowersGained;
                }
                
                else
                {
                    totalFollowers = (int) streamer.Followers + holder.FollowersGained;
                }
                
                
                //Parameter By Value
                if (paramByValue)
                {
                    val = paramByValueBad(totalFollowers);
                }

                else
                {
                    val = paramByValueGood(ref totalFollowers);
                }
            }
        }


        static private int paramByValueBad(int followers)
        {
            int a = followers * 3;
            int b = a + followers;
            return b / 2;
        }

        static private int paramByValueGood(ref int followers)
        {
            int a = followers * 3;
            int b = a + followers;
            return b / 2;
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

        private class followerInfoHolder()
        {
            public UInt32 Followers { get; set; }
            public int FollowersGained { get; set; }
            public followerInfoHolder(StreamerBase _streamer)
            {
                Followers = _streamer.Followers;
                FollowersGained = _streamer.FollowersGained;
            }
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
        public uint PeakViewers { get; set; }
        [Name("Average viewers")]
        public uint AvgViewers { get; set; }
        [Name("Followers")]
        public UInt32 Followers { get; set; }
        [Name("Followers gained")]
        public int FollowersGained { get; set; }
        [Name("Views gained")]
        public int ViewsGained { get; set; }
        [Name("Partnenred")]
        public bool Partnered { get; set; }
        [Name("Mature")]
        public bool Mature { get; set; }
        [Name("Language")]
        public string Language { get; set; }
        
        public double radiusOfFollowers { get; set; }

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