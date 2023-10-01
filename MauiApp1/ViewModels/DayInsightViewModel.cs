using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sleepwise.Models;
using Sleepwise.Services;

namespace Sleepwise.ViewModels
{
    public class DayInsightViewModel : INotifyPropertyChanged
    {
        SQLiteConnection connection;

        public DayInsightViewModel()
        {
            connection = DatabaseService.Connection;
            LoadDayInsight();
        }

        private string _exerciseLevel;

        public string ExerciseLevel
        {
            get { return _exerciseLevel; }
            set
            {
                if (_exerciseLevel != value)
                {
                    _exerciseLevel = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _food;
        public string Food
        {
            get { return _food; }
            set
            {
                if (_food != value)
                {
                    _food = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _foodQuality;
        public string FoodQuality
        {
            get { return _foodQuality; }
            set
            {
                if (_foodQuality != value)
                {
                    _foodQuality = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _work;
        public string Work
        {
            get { return _work; }
            set
            {
                if (_work != value)
                {
                    _work = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _workExperience;
        public string WorkExperience
        {
            get { return _workExperience; }
            set
            {
                if (_workExperience != value)
                {
                    _workExperience = value;
                    OnPropertyChanged();
                }
            }
        }

        private void LoadDayInsight()
        {
            var insight= connection.Table<DayInsightModel>().LastOrDefault();

            if (insight != null)
            {
                ExerciseLevel = insight.ExerciseLevel;
                Food = insight.Food;
                FoodQuality = insight.FoodQuality;
                Work = insight.Work;
                WorkExperience = insight.WorkExperience;
            }
        }

        public void SaveDayInsight()
        {
            var dayInsight = new DayInsightModel
            {
                ExerciseLevel = _exerciseLevel,
                Food = _food,
                FoodQuality = _foodQuality,
                Work = _work,
                WorkExperience = _workExperience
            };
            if (dayInsight.Id > 0)
            {
                connection.Update(dayInsight);
            }
            else
            {
                connection.Insert(dayInsight);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
