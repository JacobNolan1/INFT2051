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

    public static class SleepInsights
    {
        public static readonly Dictionary<InsightEnums, InsightMapping> insightMappings = new Dictionary<InsightEnums, InsightMapping>
        {
            { InsightEnums.Alcohol, new InsightMapping("Alcohol", FontAwesomeIconsSolid.BeerMugEmpty)},
            { InsightEnums.SleepWell, new InsightMapping("Slept Well", FontAwesomeIconsSolid.Bed)},
            { InsightEnums.Tired, new InsightMapping("Tired", FontAwesomeIconsSolid.FaceTired)}
        };

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
