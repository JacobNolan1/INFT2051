using Sleepwise.Models;
using Sleepwise.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sleepwise.ViewModels
{
    public class DayTimeRatingInsightViewModel : ObservableObject
    {
        public static DayTimeRatingInsightViewModel Current { get; set; }
        private readonly SQLiteConnection _connection;

        public DayTimeRatingInsightViewModel()
        {
            Current = this;
            _connection = DatabaseService.Connection;
        }

        private DayTimeRatingInsightModel _selectedDayTimeRatingInsight;

        public DayTimeRatingInsightModel SelectedDayTimeRatingInsight
        {
            get { return _selectedDayTimeRatingInsight; }
            set
            {
                if (_selectedDayTimeRatingInsight != value)
                {
                    _selectedDayTimeRatingInsight = value;
                    OnPropertyChanged(nameof(_selectedDayTimeRatingInsight));
                }
            }
        }
        public List<DayTimeRatingInsightModel> LoadPositiveRatingInsight()
        {
            int user_id = Preferences.Default.Get<int>("user_id", -1);
            List<DayTimeRatingInsightModel> DayPositiveInsight = _connection.Table<DayTimeRatingInsightModel>()
                .Where(insight => insight.UserId == user_id)
                .GroupBy(insight => new { insight.Question, insight.Selection })
                .Select(group => new DayTimeRatingInsightModel
                {
                    Question = group.Key.Question,
                    Selection = group.Key.Selection,
                    TotalPositiveRating = group.Sum(insight => insight.PositiveRating)
                })
                .OrderByDescending(result => result.TotalPositiveRating)
                .Take(3).ToList();
            return DayPositiveInsight;
        }
        public List<DayTimeRatingInsightModel> LoadNegativeRatingInsight()
        {
            int user_id = Preferences.Default.Get<int>("user_id", -1);

            List<DayTimeRatingInsightModel> DayNegativeInsight = _connection.Table<DayTimeRatingInsightModel>()
            .Where(insight => insight.UserId == user_id)
            .GroupBy(insight => new { insight.Question, insight.Selection })
            .Select(group => new DayTimeRatingInsightModel
            {
                Question = group.Key.Question,
                Selection = group.Key.Selection,
                TotalNegativeRating = group.Sum(insight => insight.NegativeRating)
            })
            .OrderBy(result => result.TotalNegativeRating)
            .Take(3).ToList();
            return DayNegativeInsight;
        }

    }
}
