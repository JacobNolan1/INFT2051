using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sleepwise.Models
{
    [SQLite.Table("nighttime_insights")]
    public class NightTimeInsightModel : INotifyPropertyChanged
    {
        public NightTimeInsightModel()
        {
            _sleepDuration = string.Empty;
            _sleepQuality = string.Empty;
            _screens = string.Empty;
        }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }


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



        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
