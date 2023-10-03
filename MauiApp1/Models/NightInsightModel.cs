using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sleepwise.Models
{
    [SQLite.Table("night_insights")]
    public class NightInsightModel : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }


        private string _summaryRating;
        [MaxLength(20)]
        public string SummaryRating
        {
            get { return _summaryRating; }
            set { _summaryRating = value; }
        }


        private string _sleepDuration;
        [MaxLength(20)]
        public string SleepDuration
        {
            get { return _sleepDuration; }
            set { _sleepDuration = value; }
        }



        private string _sleepQuality;
        [MaxLength(20)]
        public string SleepQuality
        {
            get { return _sleepQuality; }
            set { _sleepQuality = value; }
        }


        private string _screens;
        [MaxLength(20)]
        public string Screens
        {
            get { return _screens; }
            set { _screens = value; }
        }


        public int UserId { get; set; }

        private DateTime _summaryDatetime;
        public DateTime SummaryDatetime
        {
            get { return _summaryDatetime; }
            set
            {
                if (_summaryDatetime != value)
                {
                    _summaryDatetime = value;
                }
            }
        }


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NightInsightModel()
        {
            _sleepDuration = string.Empty;
            _sleepQuality = string.Empty;
            _screens = string.Empty;
        }
    }
}
