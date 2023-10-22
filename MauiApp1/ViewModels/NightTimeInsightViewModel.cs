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
    public class NightTimeInsightViewModel : ObservableObject
    {
        public static NightTimeInsightViewModel Current { get; set; }
        private readonly SQLiteConnection _connection;

        public NightTimeInsightViewModel()
        {
            Current = this;
            _connection = DatabaseService.Connection;
        }

        private NightTimeInsightModel _selectedNightTimeInsight;

        public NightTimeInsightModel SelectedNightTimeInsight
        {
            get { return _selectedNightTimeInsight; }
            set
            {
                if (_selectedNightTimeInsight != value)
                {
                    _selectedNightTimeInsight = value;
                    OnPropertyChanged(nameof(SelectedNightTimeInsight));
                }
            }
        }

        public void LoadLatestNightTimeInsight()
        {
            SelectedNightTimeInsight = _connection.Table<NightTimeInsightModel>().OrderByDescending(x => x.Id).LastOrDefault();

            if (SelectedNightTimeInsight == null)
            {
                SelectedNightTimeInsight = new NightTimeInsightModel
                {
                };
            }
        }
        public void LoadNightTimeInsightForDate(int user_id, DateTime date)
        {
            if (user_id == -1)
            {
                SelectedNightTimeInsight = null;
            }
            else
            {
                SelectedNightTimeInsight = _connection.Table<NightTimeInsightModel>()
                    .Where(x => x.SummaryDatetime == date.Date && x.UserId == user_id)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();
            }

            if (SelectedNightTimeInsight == null)
            {
                SelectedNightTimeInsight = new NightTimeInsightModel
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


        public void SaveNightTimeInsight(NightTimeInsightModel model)
        {
            var recordsToDelete = _connection.Table<NightTimeRatingInsightModel>()
            .Where(x => x.SummaryDatetime == model.SummaryDatetime && x.UserId == model.UserId)
            .ToList();

            // Delete the matching records
            foreach (var record in recordsToDelete)
            {
                _connection.Delete(record);
            }
            if (model.SleepDuration != null && model.SleepDuration != "")
            {
                NightTimeRatingInsightModel ratingInsightModel = new NightTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Sleep Duration",
                    Selection = model.SleepDuration,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }
            if (model.SleepQuality != null && model.SleepQuality != "")
            {
                NightTimeRatingInsightModel ratingInsightModel = new NightTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Sleep Quality",
                    Selection = model.SleepQuality,
                    PositiveRating = getPositiveRating(model.SummaryRating),
                    NegativeRating = getNegativeRating(model.SummaryRating),
                };
                _connection.Insert(ratingInsightModel);
            }
            if (model.Screens != null && model.Screens != "")
            {
                NightTimeRatingInsightModel ratingInsightModel = new NightTimeRatingInsightModel
                {
                    UserId = model.UserId,
                    SummaryDatetime = model.SummaryDatetime,
                    Question = "Screens",
                    Selection = model.Screens,
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

        public void DeleteNightTimeInsight(NightTimeInsightModel model)
        {
            if (model.Id > 0)
            {
                _connection.Delete(model);
            }
        }
    }
}