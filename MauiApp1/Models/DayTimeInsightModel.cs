using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sleepwise.Models
{
    [SQLite.Table("daytime_insights")]
    public class DayTimeInsightModel : INotifyPropertyChanged
    {
        public DayTimeInsightModel()
        {
            _exerciseLevel = string.Empty;
            _food= string.Empty;
            _foodQuality = string.Empty;
            _work = string.Empty;
            _workExperience = string.Empty;
        }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }


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

        private string _exerciseLevel;
        [MaxLength(20)]
        public string ExerciseLevel
        {
            get { return _exerciseLevel; }
            set { _exerciseLevel = value; }
        }

        private string _food;
        [MaxLength(20)]
        public string Food
        {
            get { return _food; }
            set { _food = value; }
        }

        private string _foodQuality;
        [MaxLength(20)]
        public string FoodQuality
        {
            get { return _foodQuality; }
            set { _foodQuality = value; }
        }


        private string _work;
        [MaxLength(20)]
        public string Work
        {
            get { return _work; }
            set { _work = value; }
        }

        private string _workExperience;
        [MaxLength(20)]
        public string WorkExperience
        {
            get { return _workExperience; }
            set { _workExperience = value; }
        }



        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
