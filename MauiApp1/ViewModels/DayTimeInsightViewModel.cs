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



        public void SaveDayTimeInsight(DayTimeInsightModel model)
        {
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
