using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sleepwise.Models
{
    public class DailySummaryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsNightSummary { get; set; }
        public bool IsDaySummary { get; set; }

        public MoodEnums moodEnum { get; set; }
        

        private List<InsightEnums> _insight;

        public List<InsightMapping> InsightsString
        {
            get {
                List<InsightMapping> result = _insight.Select(insightEnum =>
                {
                    if (SleepInsights.insightMappings.TryGetValue(insightEnum, out var insightMapping))
                    {
                        return insightMapping;
                    }
                    return null;
                }).Where(insightMapping => insightMapping != null).ToList();
                return result;
            }
        }
        public List<InsightEnums> Insights
        {
            get { return _insight; }
            set
            {
                _insight = value;
            }
        }
        // Helper method to raise PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
