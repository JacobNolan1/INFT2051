using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sleepwise.Models
{
    public enum InsightEnums
    {
        Alcohol,
        SleepWell,
        Tired
    }
    public enum MoodEnums
    {
        Terrible,
        Bad,
        Average,
        Good,
        Amazing,
    }


    public static class Moods
    {
        public static readonly Dictionary<MoodEnums, MoodMapping> moodMappings = new Dictionary<MoodEnums, MoodMapping>
        {
            { MoodEnums.Terrible, new MoodMapping("Terrible", "sad_full.png")},
            { MoodEnums.Bad, new MoodMapping("Bad", "sad.png")},
            { MoodEnums.Average, new MoodMapping("Average", "meh.png")},
            { MoodEnums.Good, new MoodMapping("Good", "happy.png")},
            { MoodEnums.Amazing, new MoodMapping("Amazing", "happy_full.png")}
        };

    }

    public static class SleepInsights
    {
        public static readonly Dictionary<InsightEnums, InsightMapping> insightMappings = new Dictionary<InsightEnums, InsightMapping>
        {
            { InsightEnums.Alcohol, new InsightMapping("Alcohol", FontAwesomeIconsSolid.BeerMugEmpty)},
            { InsightEnums.SleepWell, new InsightMapping("Slept Well", FontAwesomeIconsSolid.Bed)},
            { InsightEnums.Tired, new InsightMapping("Tired", FontAwesomeIconsSolid.FaceTired)}
        };

    }

    public class MoodMapping
    {
        public MoodMapping(string moodString, string moodImageName)
        {
            this.MoodString = moodString;
            this.MoodImageName = moodImageName;
            this.ImageSrc = moodImageName;
        }
        public string MoodString { get; set; }
        public string MoodImageName { get; set; }
        public string ImageSrc { get; set; }
    }
    public class InsightMapping
    {
        public InsightMapping(string insightString, string insightIcon)
        {
            this.InsightString = insightString;
            this.InsightIcon = insightIcon;
        }
        public string InsightString { get; set; }
        public string InsightIcon { get; set; }
    }
}
