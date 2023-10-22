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
    public class DayTimeInsightViewModel : ObservableObject
    {
        public static DayTimeInsightViewModel Current { get; set; }
        private readonly SQLiteConnection _connection;

        public DayTimeInsightViewModel()
        {
            Current = this;
            _connection = DatabaseService.Connection;
        }

        private DayTimeInsightModel _selectedDayTimeInsight;

        public DayTimeInsightModel SelectedDayTimeInsight
        {
            get { return _selectedDayTimeInsight; }
            set
            {
                if (_selectedDayTimeInsight != value)
                {
                    _selectedDayTimeInsight = value;
                    OnPropertyChanged(nameof(SelectedDayTimeInsight));
                }
            }
        }

        public void LoadLatestDayTimeInsight()
        {
            SelectedDayTimeInsight = _connection.Table<DayTimeInsightModel>().OrderByDescending(x => x.Id).LastOrDefault();

            if (SelectedDayTimeInsight == null)
            {
                SelectedDayTimeInsight = new DayTimeInsightModel
                {
                };
            }
        }
        public void LoadDayTimeInsightForDate(int user_id, DateTime date)
        {
            if (user_id == -1)
            {
                SelectedDayTimeInsight = null;
            }
            else
            {
                SelectedDayTimeInsight = _connection.Table<DayTimeInsightModel>()
                    .Where(x => x.SummaryDatetime == date.Date && x.UserId == user_id)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();
            }

            if (SelectedDayTimeInsight == null)
            {
                SelectedDayTimeInsight = new DayTimeInsightModel
                {
                    UserId = user_id,
                    SummaryDatetime = date,
                    IsCompleted = false,
                };
            }
        }

        public int getPositiveRating(string rating)
        {
            Dictionary<string, int> ratingMapping = new Dictionary<string, int>
            {
                { "terrible", -2 },
                { "bad", -1 },
                { "average", 0 },
                { "good", 1 },
                { "amazing", 2 }
            };
            if (ratingMapping[rating] > 0)
            {
                return ratingMapping[rating];
            }
            return 0;
        }
        public int getNegativeRating(string rating)
        {
            Dictionary<string, int> ratingMapping = new Dictionary<string, int>
            {
                { "terrible", -2 },
                { "bad", -1 },
                { "average", 0 },
                { "good", 1 },
                { "amazing", 2 }
            };
            
            if (ratingMapping[rating] < 0)
            {
                return ratingMapping[rating];
            }
            return 0;
        }

        public void SaveDayTimeInsight(DayTimeInsightModel model)
        {
            var recordsToDelete = _connection.Table<DayTimeRatingInsightModel>()
                .Where(x => x.SummaryDatetime == model.SummaryDatetime && x.UserId == model.UserId)
                .ToList();

            // Delete the matching records
            foreach (var record in recordsToDelete)
            {
                _connection.Delete(record);
            }

            if (model.ExerciseLevel != null && model.ExerciseLevel != "")
            {
                DayTimeRatingInsightModel ratingInsightModel = new DayTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Exercise Level",
                    Selection = model.ExerciseLevel,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }
            if (model.Food != null && model.Food != "")
            {
                DayTimeRatingInsightModel ratingInsightModel = new DayTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Food",
                    Selection = model.Food,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }
            if (model.FoodQuality != null && model.FoodQuality != "")
            {
                DayTimeRatingInsightModel ratingInsightModel = new DayTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Food Quality",
                    Selection = model.FoodQuality,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }
            if (model.Work != null && model.Work != "")
            {
                DayTimeRatingInsightModel ratingInsightModel = new DayTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Work",
                    Selection = model.Work,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }
            if (model.WorkExperience != null && model.WorkExperience != "")
            {
                DayTimeRatingInsightModel ratingInsightModel = new DayTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Work Experience",
                    Selection = model.WorkExperience,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }



            model.IsCompleted = true;
            if (model.Id > 0)
            {
                _connection.Update(model);
            }
            else
            {
                _connection.Insert(model);
            }
        }

        public void DeleteDayTimeInsight(DayTimeInsightModel model)
        {
            if (model.Id > 0)
            {
                _connection.Delete(model);
            }
        }
    }
}
