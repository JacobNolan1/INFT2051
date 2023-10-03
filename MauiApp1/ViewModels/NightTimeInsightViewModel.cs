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



        public void SaveNightTimeInsight(NightTimeInsightModel model)
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

        public void DeleteNightTimeInsight(NightTimeInsightModel model)
        {
            if (model.Id > 0)
            {
                _connection.Delete(model);
            }
        }
    }
}
