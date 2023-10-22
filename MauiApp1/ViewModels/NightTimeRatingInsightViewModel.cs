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
    public class NightTimeRatingInsightViewModel : ObservableObject
    {
        public static NightTimeRatingInsightViewModel Current { get; set; }
        private readonly SQLiteConnection _connection;

        public NightTimeRatingInsightViewModel()
        {
            Current = this;
            _connection = DatabaseService.Connection;
        }

        private NightTimeRatingInsightModel _selectedNightTimeRatingInsight;

        public NightTimeRatingInsightModel SelectedNightTimeRatingInsight
        {
            get { return _selectedNightTimeRatingInsight; }
            set
            {
                if (_selectedNightTimeRatingInsight != value)
                {
                    _selectedNightTimeRatingInsight = value;
                    OnPropertyChanged(nameof(_selectedNightTimeRatingInsight));
                }
            }
        }


        public List<NightTimeRatingInsightModel> LoadPositiveRatingInsight()
        {
            int user_id = Preferences.Default.Get<int>("user_id", -1);

            List<NightTimeRatingInsightModel> NightPositiveInsight = _connection.Table<NightTimeRatingInsightModel>()
                .Where(insight => insight.UserId == user_id)
                .GroupBy(insight => new { insight.Question, insight.Selection })
                .Select(group => new NightTimeRatingInsightModel
                {
                    Question = group.Key.Question,
                    Selection = group.Key.Selection,
                    TotalPositiveRating = group.Sum(insight => insight.PositiveRating)
                })
                .OrderByDescending(result => result.TotalPositiveRating)
                .Take(3).ToList();
            return NightPositiveInsight;
        }
        public List<NightTimeRatingInsightModel> LoadNegativeRatingInsight()
        {
            int user_id = Preferences.Default.Get<int>("user_id", -1);

            List<NightTimeRatingInsightModel> NightNegativeInsight = _connection.Table<NightTimeRatingInsightModel>()
            .Where(insight => insight.UserId == user_id)
            .GroupBy(insight => new { insight.Question, insight.Selection })
            .Select(group => new NightTimeRatingInsightModel
            {
                Question = group.Key.Question,
                Selection = group.Key.Selection,
                TotalNegativeRating = group.Sum(insight => insight.NegativeRating)
            })
            .OrderBy(result => result.TotalNegativeRating)
            .Take(3).ToList();
            return NightNegativeInsight;
        }
    }
}

