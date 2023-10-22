using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sleepwise.Models
{
    [SQLite.Table("nighttime_rating_insights")]
    public class NightTimeRatingInsightModel : INotifyPropertyChanged
    {
        public NightTimeRatingInsightModel()
        {
        }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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
        private string _question;
        [MaxLength(20)]
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }
        private string _selection;
        [MaxLength(20)]
        public string Selection
        {
            get { return _selection; }
            set { _selection = value; }
        }

        private int _positiveRating;
        public int PositiveRating
        {
            get { return _positiveRating; }
            set { _positiveRating = value; }
        }

        private int _negativeRating;
        public int NegativeRating
        {
            get { return _negativeRating; }
            set { _negativeRating = value; }
        }

        private int _totalPositiveRating;
        public int TotalPositiveRating

        {
            get { return _totalPositiveRating; }
            set { _totalPositiveRating = value; }
        }

        private int _totalNegativeRating;
        public int TotalNegativeRating
        {
            get { return _totalNegativeRating; }
            set { _totalNegativeRating = value; }
        }



        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


