using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sleepwise.Models.Old
{
    public class DailySummaryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsNightSummary { get; set; }
        public bool IsDaySummary { get; set; }

        public MoodEnums moodEnum { get; set; }

        public string imagePath
        {
            get
            {
                return "happy.png";
            }
        }
        public ImageSource MyImageSource
        {
            get
            {
                var mood = moodEnum;
                var src = Moods.moodMappings[moodEnum].ImageSrc;
                return Moods.moodMappings[moodEnum].ImageSrc;
                if (Moods.moodMappings.TryGetValue(moodEnum, out var moodMapping))
                {
                    var ret = moodMapping.ImageSrc;
                }
                return "sad.png";
            }
        }

        public string moodImageName
        {
            get
            {

                if (Moods.moodMappings.TryGetValue(moodEnum, out var moodMapping))
                {
                    return moodMapping.MoodImageName;
                }
                return "-";
            }
        }
        public ImageSource moodImageSource
        {
            get
            {

                if (Moods.moodMappings.TryGetValue(moodEnum, out var moodMapping))
                {
                    return moodMapping.ImageSrc;
                }
                return "-";
            }

        }
        private List<InsightEnums> _insight;

        public List<InsightMapping> InsightsString
        {
            get
            {
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
