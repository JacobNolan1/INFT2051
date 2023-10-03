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
    public class NightInsightViewModel : ObservableObject
    {
        public static NightInsightViewModel Current { get; set; }
        private readonly SQLiteConnection _connection;

        public NightInsightViewModel()
        {
            Current = this;
            _connection = DatabaseService.Connection;
        }

        private NightInsightModel _selectedNightInsight;

        public NightInsightModel SelectedNightInsight
        {
            get { return _selectedNightInsight; }
            set
            {
                if (_selectedNightInsight != value)
                {
                    _selectedNightInsight = value;
                    OnPropertyChanged(nameof(SelectedNightInsight));
                }
            }
        }

        public void LoadLatestNightInsight()
        {
            SelectedNightInsight = _connection.Table<NightInsightModel>().OrderByDescending(x => x.Id).LastOrDefault();

            if (SelectedNightInsight == null)
            {
                SelectedNightInsight = new NightInsightModel
                {
                };
            }
        }
        public void LoadNightInsightForDate(int user_id, DateTime date)
        {
            if (user_id == -1)
            {
                SelectedNightInsight = null;
            } else
            {
                SelectedNightInsight = _connection.Table<NightInsightModel>()
                    .Where(x => x.SummaryDatetime == date.Date && x.UserId == user_id)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();
            }

            if (SelectedNightInsight == null)
            {
                SelectedNightInsight = new NightInsightModel
                {
                    UserId = user_id,
                    SummaryDatetime = date,
                    IsCompleted = false,
                };
            }
        }



        public void SaveNightInsight(NightInsightModel model)
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

        public void DeleteNightInsight(NightInsightModel model)
        {
            if (model.Id > 0)
            {
                _connection.Delete(model);
            }
        }
    }
}
